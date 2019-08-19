using System;
using System.Collections.ObjectModel;

namespace RCDesktopUI.Helpers
{
    public static class KeyboardKeysToObservableCollection
    {
        public static ObservableCollection<string> ToObservableStringCollection(this Type keys)
        {
            ObservableCollection<string> output = new ObservableCollection<string>();
            foreach (string key in Enum.GetNames(keys))
            {
                output.Add(key);
            }

            return output;
        }
    }
}
