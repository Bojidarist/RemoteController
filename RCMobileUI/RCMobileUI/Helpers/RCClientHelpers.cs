using RCLib.Client;
using SimpleTCPStandar;
using System;
using System.Linq;
using System.Net.Sockets;

namespace RCMobileUI.Helpers
{
    /// <summary>
    /// Methods for easier use of <see cref="RCClient"/> in <see cref="RCMobileUI"/>
    /// </summary>
    public static class RCClientHelpers
    {
#pragma warning disable IDE0060 // Remove unused parameter
        /// <summary>
        /// Pings to see if a RemoteController server is active and if it is, return the IP
        /// </summary>
        /// <param name="client">The <see cref="RCClient"/> object</param>
        public static string GetActiveServerIP(this RCClient client)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            int maxLength = 254;
            string localIP = new SimpleTcpServer().GetIPAddresses().FirstOrDefault().MapToIPv4().ToString();
            if (localIP == null)
            {
                return null;
            }

            localIP = localIP.Remove(localIP.LastIndexOf('.'));
            string localIPWithoutID = localIP;
            for (int i = 0; i <= maxLength; i++)
            {
                try
                {
                    localIP = $"{ localIPWithoutID }.{ i }";
                    using (var tcpClient = new TcpClient())
                    {
                        if (!tcpClient.ConnectAsync(localIP, 8910).Wait(100))
                        {
                            throw new Exception();
                        }
                        break;
                    }
                }
                catch (Exception)
                {
                    if (i == maxLength)
                    {
                        return null;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return localIP;
        }
    }
}
