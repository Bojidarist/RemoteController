using RCLib.Models;
using RCLib.Models.ConsoleSpecific;
using RCLib.Server;

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
    }
}
