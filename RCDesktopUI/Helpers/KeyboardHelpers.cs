using RCLib.Models;
using System.Collections.ObjectModel;

namespace RCDesktopUI.Helpers
{
    public static class KeyboardHelpers
    {
        /// <summary>
        /// A list of keys
        /// </summary>
        public static ObservableCollection<string> KeyboardKeys { get; set; } = typeof(KeyboardKeysEnum).ToObservableStringCollection();
    }
}
