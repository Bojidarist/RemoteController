using AutoSharp;
using RCLib.Models;

namespace RCDesktopUI.ValueConverters
{
    public static class ConsoleKeyStateEnumToKeyboardEventFlagConverter
    {
        /// <summary>
        /// Converts the <see cref="ConsoleKeyStateEnum"/> to <see cref="KeyboardEventFlags"/>
        /// </summary>
        public static KeyboardEventFlags Convert(ConsoleKeyStateEnum state)
        {
            switch (state)
            {
                case ConsoleKeyStateEnum.NONE:
                    return KeyboardEventFlags.NONE;
                case ConsoleKeyStateEnum.PRESSED:
                    return KeyboardEventFlags.KEYEVENTF_EXTENDEDKEY;
                case ConsoleKeyStateEnum.RELEASED:
                    return KeyboardEventFlags.KEYEVENTF_KEYUP;
                default:
                    return KeyboardEventFlags.NONE;
            }
        }
    }
}
