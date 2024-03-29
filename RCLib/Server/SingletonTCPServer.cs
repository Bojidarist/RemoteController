﻿using SimpleTCPStandar;

namespace RCLib.Server
{
    /// <summary>
    /// A singleton TCP server to prevent multiple instance errors
    /// </summary>
    static class SingletonTCPServer
    {
        /// <summary>
        /// The TCP server
        /// </summary>
        public static SimpleTcpServer singleTCPServer { get; } = new SimpleTcpServer();
    }
}
