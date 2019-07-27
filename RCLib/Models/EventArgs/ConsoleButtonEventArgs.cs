using System;
using System.Collections.Generic;
using System.Text;

namespace RCLib.Models
{
    public class ConsoleButtonEventArgs : EventArgs
    {
        public IConsoleButton ConsoleButton { get; private set; }

        public ConsoleButtonEventArgs(IConsoleButton button)
        {
            this.ConsoleButton = button;
        }
    }
}
