using AutoSharp;
using RCDesktopUI.ValueConverters;
using RCLib.Helpers;
using RCLib.Models;
using System;
using System.Collections.ObjectModel;

namespace RCDesktopUI.Helpers
{
    public static class KeyboardKeysHelper
    {
        /// <summary>
        /// Get observable collection with the names of an enum
        /// </summary>
        public static ObservableCollection<string> ToObservableStringCollection(this Type keys)
        {
            ObservableCollection<string> output = new ObservableCollection<string>();
            foreach (string key in Enum.GetNames(keys))
            {
                output.Add(key);
            }

            return output;
        }

        /// <summary>
        /// Convert a string with a key name like "E" and convert to <see cref="KeyboardKeyCodes"/>
        /// </summary>
        /// <param name="key">The key to be converted</param>
        public static KeyboardKeyCodes ToKeyboardKeyCode(this string key)
        {
            // Get the key as KeyboardKeysEnum
            var kbKey = EnumHelpers.ParseEnum<KeyboardKeysEnum>(key);

            // Convert it to KeyboardKeyCodes and return
            return KeyboardKeyToKeyCodeConverter.Convert(kbKey);
        }
    }
}
