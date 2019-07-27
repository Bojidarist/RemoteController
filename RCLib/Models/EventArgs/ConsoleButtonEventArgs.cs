using System;

namespace RCLib.Models
{
    /// <summary>
    /// The event arguments for event that passes <see cref="IConsoleButton"/>
    /// </summary>
    public class ConsoleButtonEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="IConsoleButton"/> passed by the event
        /// </summary>
        public IConsoleButton ConsoleButton { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="button">The <see cref="IConsoleButton"/> that this event will pass</param>
        public ConsoleButtonEventArgs(IConsoleButton button)
        {
            this.ConsoleButton = button;
        }
    }
}
