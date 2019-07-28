using System;

namespace RCLib.Helpers
{
    /// <summary>
    /// Methods for easier use of <see cref="Enum"/>
    /// </summary>
    public static class EnumHelpers
    {
        /// <summary>
        /// Parses a string to Enum value
        /// </summary>
        /// <typeparam name="T">The type of Enum</typeparam>
        /// <param name="value">The value to parse</param>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
