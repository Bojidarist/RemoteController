using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using RCLib.Helpers;
using RCLib.Models;
using System.Text;
using System.Net.Sockets;

namespace RCLib.Server
{
    /// <summary>
    /// A class for managing the server's properties and events
    /// </summary>
    public class ServerManager
    {
        #region Public properties

        /// <summary>
        /// This event fires when the current server instance receives a new message
        /// </summary>
        public event EventHandler<ConsoleButtonEventArgs> ServerDataReceived;

        /// <summary>
        /// This event fires when a device/client is connected to the server
        /// </summary>
        public event EventHandler<TcpClient> DeviceConnected;

        /// <summary>
        /// This event fires when a device/client is disconnected from the server
        /// </summary>
        public event EventHandler<TcpClient> DeviceDisconnected;

        /// <summary>
        /// The current IP address used by the server
        /// </summary>
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// The current port used by the server
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The number of connected devices
        /// </summary>
        public int ConnectedDevicesCount { get { return SingletonTCPServer.singleTCPServer.ConnectedClientsCount; } }

        /// <summary>
        /// The encoding used by the server when sending/receiving messages
        /// </summary>
        public Encoding ServerStringEncoding
        {
            get
            {
                return SingletonTCPServer.singleTCPServer.StringEncoder;
            }
            set
            {
                SingletonTCPServer.singleTCPServer.StringEncoder = value;
            }
        }

        /// <summary>
        /// Indicates if the server is already started
        /// </summary>
        public bool IsServerStarted { get { return SingletonTCPServer.singleTCPServer.IsStarted; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="privateIP">The private ip of the system</param>
        /// <param name="port">The port used by the server</param>
        public ServerManager(string privateIP, int port)
        {
            // Set the IP address and port
            this.PrivateIPAddress = privateIP;
            this.Port = port;

            // Event listeners
            this.SetUpEventListeners();
        }

        /// <summary>
        /// Constructor that tries to figure out the private ip of the system
        /// </summary>
        /// <param name="port">The port used by the server</param>
        public ServerManager(int port)
        {
            // Set the IP address and port
            this.PrivateIPAddress = this.FindLocalIPv4();
            this.Port = port;

            // Event listeners
            this.SetUpEventListeners();
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ServerManager()
        {
            // Event listeners
            this.SetUpEventListeners();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start the current server if it is not already started
        /// </summary>
        public void StartServer()
        {
            if (!this.IsServerStarted && !String.IsNullOrWhiteSpace(this.PrivateIPAddress) && this.Port != 0)
            {
                SingletonTCPServer.singleTCPServer.Start(IPAddress.Parse(this.PrivateIPAddress), this.Port);
            }
        }

        /// <summary>
        /// Stop the current server if it is already running
        /// </summary>
        public void StopServer()
        {
            if (this.IsServerStarted)
            {
                SingletonTCPServer.singleTCPServer.Stop();
            }
        }

        /// <summary>
        /// Broadcast a message to all connected clients
        /// </summary>
        /// <param name="message">The message to be broadcasted</param>
        public void BroadcastMessage(string message)
        {
            SingletonTCPServer.singleTCPServer.Broadcast(message);
        }

        /// <summary>
        /// A method that tries to find the local IPv4 address of the system
        /// </summary>
        /// <param name="throwExceptionIfNullOrWhiteSpace">Indicates if exception will be thrown if this method cannot find an IP address</param>
        public string FindLocalIPv4(bool throwExceptionIfNullOrWhiteSpace = false)
        {
            string ip = SingletonTCPServer.singleTCPServer.GetIPAddresses().FirstOrDefault().MapToIPv4().ToString();
            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = this.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
                if (string.IsNullOrWhiteSpace(ip))
                {
                    ip = this.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                    if (string.IsNullOrWhiteSpace(ip))
                    {
                        if (throwExceptionIfNullOrWhiteSpace)
                        {
                            throw new NullReferenceException("The IP address is not found.");
                        }
                        else
                        {
                            return ip;
                        }
                    }
                }
            }

            return ip;
        }

        /// <summary>
        /// Private helper method to easily set up event listeners
        /// </summary>
        private void SetUpEventListeners()
        {
            SingletonTCPServer.singleTCPServer.DataReceived += SingleTCPServer_DataReceived;
            SingletonTCPServer.singleTCPServer.ClientConnected += SingleTCPServer_ClientConnected;
            SingletonTCPServer.singleTCPServer.ClientDisconnected += SingleTCPServer_ClientDisconnected;
        }

        #endregion

        #region Events

        /// <summary>
        /// The event from the singleton server that fires when a message is received
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The received message</param>
        private void SingleTCPServer_DataReceived(object sender, SimpleTCPStandar.Message e)
        {
            // Split all inputs (useful if there are alot of inputs at the same time)
            string[] inputs = e.MessageString.ReturnCleanASCII().Split(new char[] { ' ' }, 100, StringSplitOptions.RemoveEmptyEntries);
            foreach (string input in inputs)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    IConsoleButton data = this.ParseConsoleButtonFromCSV(input.ReturnCleanASCII());
                    this.ServerDataReceived?.Invoke(this, new ConsoleButtonEventArgs(data));
                }
            }
        }

        /// <summary>
        /// The event from the singleton server that fires when a device/client is connected
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The client</param>
        private void SingleTCPServer_ClientConnected(object sender, TcpClient e)
        {
            if (e != null)
            {
                this.DeviceConnected?.Invoke(this, e);
            }
        }

        /// <summary>
        /// The event from the singleton server that fires when a device/client is disconnected from the server
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The client</param>
        private void SingleTCPServer_ClientDisconnected(object sender, TcpClient e)
        {
            if (e != null)
            {
                this.DeviceDisconnected?.Invoke(this, e);
            }
        }

        #endregion
    }
}
