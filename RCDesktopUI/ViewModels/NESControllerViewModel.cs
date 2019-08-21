using RCDesktopUI.Helpers;
using RCDesktopUI.Properties;
using RCDesktopUI.SelectedControllerKeys;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using System.Collections.ObjectModel;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="NESControllerPage"/>
    /// </summary>
    public class NESControllerViewModel : BaseViewModel
    {
        #region Private members

        // Selected keys
        private string mSelectedKeyLeft;
        private string mSelectedKeyRight;
        private string mSelectedKeyUp;
        private string mSelectedKeyDown;
        private string mSelectedKeySelect;
        private string mSelectedKeyStart;
        private string mSelectedKeyA;
        private string mSelectedKeyB;

        #endregion

        #region Public properties

        /// <summary>
        /// A list of keys
        /// </summary>
        public ObservableCollection<string> KeyboardKeys { get { return KeyboardHelpers.KeyboardKeys; } }

        /// <summary>
        /// The selected key for the Left button
        /// </summary>
        public string SelectedKeyLeft
        {
            get { return mSelectedKeyLeft; }
            set
            {
                mSelectedKeyLeft = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.LEFTARROW = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.LEFTARROW = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_LEFT = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the Right button
        /// </summary>
        public string SelectedKeyRight
        {
            get { return mSelectedKeyRight; }
            set
            {
                mSelectedKeyRight = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.RIGHTARROW = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.RIGHTARROW = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_RIGHT = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the Up button
        /// </summary>
        public string SelectedKeyUp
        {
            get { return mSelectedKeyUp; }
            set
            {
                mSelectedKeyUp = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.UPARROW = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.UPARROW = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_UP = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the Down button
        /// </summary>
        public string SelectedKeyDown
        {
            get { return mSelectedKeyDown; }
            set
            {
                mSelectedKeyDown = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.DOWNARROW = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.DOWNARROW = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_DOWN = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the Select button
        /// </summary>
        public string SelectedKeySelect
        {
            get { return mSelectedKeySelect; }
            set
            {
                mSelectedKeySelect = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.SELECT = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.SELECT = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_SELECT = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the Start button
        /// </summary>
        public string SelectedKeyStart
        {
            get { return mSelectedKeyStart; }
            set
            {
                mSelectedKeyStart = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.START = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.START = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_START = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the A button
        /// </summary>
        public string SelectedKeyA
        {
            get { return mSelectedKeyA; }
            set
            {
                mSelectedKeyA = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.A = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.A = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_A = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The selected key for the B button
        /// </summary>
        public string SelectedKeyB
        {
            get { return mSelectedKeyB; }
            set
            {
                mSelectedKeyB = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SelectedNESKeys.B = value.ToKeyboardKeyCode();
                }
                else
                {
                    SelectedNESKeys.B = AutoSharp.KeyboardKeyCodes.VK__none_;
                }
                Settings.Default.NES_KEY_B = value;
                Settings.Default.Save();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NESControllerViewModel()
        {
            this.LoadSettings();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load the keys from settings
        /// </summary>
        private void LoadSettings()
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_A))
            {
                this.SelectedKeyA = Settings.Default.NES_KEY_A;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_B))
            {
                this.SelectedKeyB = Settings.Default.NES_KEY_B;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_LEFT))
            {
                this.SelectedKeyLeft = Settings.Default.NES_KEY_LEFT;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_RIGHT))
            {
                this.SelectedKeyRight = Settings.Default.NES_KEY_RIGHT;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_UP))
            {
                this.SelectedKeyUp = Settings.Default.NES_KEY_UP;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_DOWN))
            {
                this.SelectedKeyDown = Settings.Default.NES_KEY_DOWN;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_SELECT))
            {
                this.SelectedKeySelect = Settings.Default.NES_KEY_SELECT;
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.NES_KEY_START))
            {
                this.SelectedKeyStart = Settings.Default.NES_KEY_START;
            }
        }

        #endregion
    }
}
