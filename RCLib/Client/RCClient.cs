using RCLib.Helpers;
using RCLib.Models;
using SimpleTCPStandar;
using System;
using System.Text;

namespace RCLib.Client
{
    /// <summary>
    /// TCPClient
    /// </summary>
    public class RCClient
    {
        #region Public properties

        /// <summary>
        /// This event fires when the client receives a new message
        /// </summary>
        public event EventHandler<ConsoleButtonEventArgs> ClientDataReceived;

        /// <summary>
        /// The SimpleTCPClient instance
        /// </summary>
        public SimpleTcpClient TcpClient { get; set; }

        /// <summary>
        /// The encoding used by the client when sending/receiving messages
        /// </summary>
        public Encoding ClientStringEncoding
        {
            get
            {
                return this.TcpClient.StringEncoder;
            }
            set
            {
                this.TcpClient.StringEncoder = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RCClient()
        {
            this.TcpClient = new SimpleTcpClient();
            this.TcpClient.DataReceived += TcpClient_DataReceived;
        }

        /// <summary>
        /// Constructor for direct connection
        /// </summary>
        /// <param name="ip">The IP of the server the client will connect to</param>
        /// <param name="port">The port of the server the client will connect to</param>
        public RCClient(string ip, int port)
        {
            this.TcpClient = new SimpleTcpClient();
            this.TcpClient.DataReceived += TcpClient_DataReceived;
            this.Connect(ip, port);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Send a message to the server the client is connected to
        /// </summary>
        /// <param name="message">The message to send</param>
        public void Write(string message)
        {
            this.TcpClient.Write(message);
        }

        /// <summary>
        /// Send a message to the server the client is connected to and add a new line
        /// </summary>
        /// <param name="message">The message to send</param>
        public void WriteLine(string message)
        {
            this.TcpClient.WriteLine(message);
        }

        /// <summary>
        /// Send a message to the server the client is connected to and get response
        /// </summary>
        /// <param name="message">The message to send</param>
        /// <param name="timeout">The timeout of the request</param>
        public Message WriteAndGetReply(string message, TimeSpan timeout)
        {
            return this.TcpClient.WriteLineAndGetReply(message, timeout);
        }

        /// <summary>
        /// Send a message to the server the client is connected to and get response
        /// </summary>
        /// <param name="message">The message to send</param>
        /// <param name="timeout">The timeout of the request (in milliseconds)</param>
        public Message WriteAndGetReply(string message, int msTimeout)
        {
            return this.TcpClient.WriteLineAndGetReply(message, TimeSpan.FromMilliseconds(msTimeout));
        }

        /// <summary>
        /// Connect to a server given a IP address and a port
        /// </summary>
        /// <param name="ip">The IP address of the server the client will connect to</param>
        /// <param name="port">The port of the server the client will connect to</param>
        public void Connect(string ip, int port)
        {
            this.TcpClient.Connect(ip, port);
        }

        /// <summary>
        /// Begins a asynchronous request to connect to a server given a IP address and a port
        /// </summary>
        /// <param name="ip">The IP address of the server the client will connect to</param>
        /// <param name="port">The port of the server the client will connect to</param>
        /// <param name="timeout">The timeout of the request (in seconds)</param>
        public void BeginConnect(string ip, int port, int timeout)
        {
            this.TcpClient.BeginConnect(ip, port, timeout);
        }

        /// <summary>
        /// Disconnect from a server if already connected
        /// </summary>
        public void Disconnect()
        {
            this.TcpClient.Disconnect();
        }

        #endregion

        #region Events

        /// <summary>
        /// The event from the TCP client that fires when data is received
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The message</param>
        private void TcpClient_DataReceived(object sender, Message e)
        {
            // Split all inputs (useful if there are alot of inputs at the same time)
            string[] inputs = e.MessageString.ReturnCleanASCII().Split(new char[] { ' ' }, 100, StringSplitOptions.RemoveEmptyEntries);
            foreach (string input in inputs)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    IConsoleButton data = ServerManagerHelpers.ParseConsoleButtonFromCSV(null, input.ReturnCleanASCII());
                    this.ClientDataReceived?.Invoke(this, new ConsoleButtonEventArgs(data));
                }
            }
        }

        #endregion
    }
}
