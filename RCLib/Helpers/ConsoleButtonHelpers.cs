using RCLib.Models;

namespace RCLib.Helpers
{
    /// <summary>
    /// Methods for easier use of <see cref="IConsoleButton"/>
    /// </summary>
    public static class ConsoleButtonHelpers
    {
        /// <summary>
        /// Parse a <see cref="IConsoleButton"/> to a CSV string
        /// (ConsoleName,KeyName,KeyState)
        /// </summary>
        /// <param name="button">The button that will be parsed</param>
        public static string ParseToCSV(this IConsoleButton button)
        {
            return $"{ button.ConsoleName },{ button.KeyName },{ button.KeyState }";
        }
    }
}
