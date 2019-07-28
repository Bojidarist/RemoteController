using System.Text;

namespace RCLib.Helpers
{
    /// <summary>
    /// Methods for easier use of <see cref="string"/>
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        /// Returns only ASCII characters
        /// </summary>
        /// <param name="input">The text to clean</param>
        public static string ReturnCleanASCII(this string input)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if ((int)c > 127 || (int)c < 32)
                    continue;
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
