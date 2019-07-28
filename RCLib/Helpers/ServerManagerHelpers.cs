using RCLib.Models;
using RCLib.Models.ConsoleSpecific;
using RCLib.Server;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace RCLib.Helpers
{
    /// <summary>
    /// Methods for easier use of <see cref="ServerManager"/>
    /// </summary>
    public static class ServerManagerHelpers
    {
        /// <summary>
        /// Parse CSV string to <see cref="IConsoleButton"/>
        /// The string should be ( ConsoleName, KeyName, KeyState )
        /// </summary>
        /// <param name="mngr">The <see cref="ServerManager"/> instance</param>
        /// <param name="csv">The CSV string</param>
        public static IConsoleButton ParseConsoleButtonFromCSV(this ServerManager mngr, string csv)
        {
            IConsoleButton result = new GenericConsoleButton();
            string[] data = csv.ToUpper().Split(',');

            result.ConsoleName = EnumHelpers.ParseEnum<ConsoleNameEnum>(data[0]);
            result.KeyName = EnumHelpers.ParseEnum<GenericKeyNameEnum>(data[1]);
            result.KeyState = EnumHelpers.ParseEnum<ConsoleKeyStateEnum>(data[2]);

            return result;
        }

        /// <summary>
        /// Get the local IPv4 of the current server depending on <see cref="NetworkInterfaceType"/>
        /// </summary>
        /// <param name="mngr">The <see cref="ServerManager"/> instance</param>
        /// <param name="networkType">The network type</param>
        public static string GetLocalIPv4(this ServerManager mngr, NetworkInterfaceType networkType)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == networkType && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
}
