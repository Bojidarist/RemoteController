using AutoSharp;
using RCDesktopUI.Properties;
using RCDesktopUI.SelectedControllerKeys;
using System;

namespace RCDesktopUI.Helpers
{
    public static class NESHelpers
    {
        /// <summary>
        /// Event that fires when <see cref="ResetNESKeySettings"/> is called
        /// </summary>
        public static event EventHandler<string> OnNESSettingsReset;

        /// <summary>
        /// Reset the key and <see cref="SelectedNESKeys"/> settings
        /// </summary>
        public static void ResetNESKeySettings()
        {
            Settings.Default.NES_KEY_A = "";
            SelectedNESKeys.A = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_B = "";
            SelectedNESKeys.B = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_LEFT = "";
            SelectedNESKeys.LEFTARROW = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_RIGHT = "";
            SelectedNESKeys.RIGHTARROW = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_UP = "";
            SelectedNESKeys.UPARROW = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_DOWN = "";
            SelectedNESKeys.DOWNARROW = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_SELECT = "";
            SelectedNESKeys.SELECT = KeyboardKeyCodes.VK__none_;

            Settings.Default.NES_KEY_START = "";
            SelectedNESKeys.START = KeyboardKeyCodes.VK__none_;

            Settings.Default.Save();
            OnNESSettingsReset?.Invoke(null, "RESET!");
        }
    }
}
