﻿using System;
using System.Linq;
using System.Net;
using RCLib.Helpers;
using RCLib.Models;

namespace RCLib.Server
{
    /// <summary>
    /// A class for managing the server's properties and events
    /// </summary>
    public class ServerManager
    {
        #region Public properties

        /// <summary>
        /// This event fires when the current server instance recieves a new message
        /// </summary>
        public event EventHandler<ConsoleButtonEventArgs> ServerDataRecieved;

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
            if (this.PrivateIPAddress == null)
            {
                throw new NullReferenceException("The IP address is null.");
            }

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

        /// <summary>
        /// Broadcast a message to all connected clients
        /// </summary>
        /// <param name="message">The message to be broadcasted</param>
        public void BroadcastMessage(string message)
        {
            SingletonTCPServer.singleTCPServer.Broadcast(message);
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
            // Split all inputs (useful if there are alot of inputs at the same time)
            string[] inputs = e.MessageString.ReturnCleanASCII().Split(new char[] { ' ' }, 100, StringSplitOptions.RemoveEmptyEntries);
            foreach (string input in inputs)
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    IConsoleButton data = this.ParseConsoleButtonFromCSV(input.ReturnCleanASCII());
                    this.ServerDataRecieved?.Invoke(this, new ConsoleButtonEventArgs(data));
                }
            }
        }

        #endregion
    }
}
