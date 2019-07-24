using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RCLib.Server
{
    public class ServerManager
    {
        #region Public properties

        /// <summary>
        /// This event fires when the current server instance recieves a new message
        /// </summary>
        public event EventHandler ServerDataRecieved;

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
            SingletonTCPServer.singleTCPServer.DataReceived += SingleTCPServer_DataReceived;
        }

        /// <summary>
        /// Constructor that tries to figure out the private ip of the system
        /// </summary>
        /// <param name="port">The port used by the server</param>
        public ServerManager(int port)
        {
            // Set the IP address and port
            this.PrivateIPAddress = SingletonTCPServer.singleTCPServer.GetIPAddresses().FirstOrDefault().MapToIPv4().ToString();
            this.Port = port;

            // Event listeners
            SingletonTCPServer.singleTCPServer.DataReceived += SingleTCPServer_DataReceived;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start the current server if it is not already started
        /// </summary>
        public void StartServer()
        {
            if (!SingletonTCPServer.singleTCPServer.IsStarted)
            {
                SingletonTCPServer.singleTCPServer.Start(IPAddress.Parse(this.PrivateIPAddress), this.Port);
            }
        }

        /// <summary>
        /// Stop the current server if it is already running
        /// </summary>
        public void StopServer()
        {
            if (SingletonTCPServer.singleTCPServer.IsStarted)
            {
                SingletonTCPServer.singleTCPServer.Stop();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// The event from the singleton server that fires when a message is recieved
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The recieved message</param>
        private void SingleTCPServer_DataReceived(object sender, SimpleTCPStandar.Message e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
