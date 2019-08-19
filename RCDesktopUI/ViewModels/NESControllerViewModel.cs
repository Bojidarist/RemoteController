using RCDesktopUI.Helpers;
using RCDesktopUI.SelectedControllerKeys;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using RCLib.Models;
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
        public ObservableCollection<string> KeyboardKeys { get; set; }

        /// <summary>
        /// The selected key for the Left button
        /// </summary>
        public string SelectedKeyLeft
        {
            get { return mSelectedKeyLeft; }
            set
            {
                mSelectedKeyLeft = value;
                SelectedNESKeys.LEFTARROW = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.RIGHTARROW = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.UPARROW = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.DOWNARROW = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.SELECT = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.START = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.A = value.ToKeyboardKeyCode();
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
                SelectedNESKeys.B = value.ToKeyboardKeyCode();
            }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NESControllerViewModel()
        {
            // Load data
            this.KeyboardKeys = typeof(KeyboardKeysEnum).ToObservableStringCollection();
        }

        #endregion
    }
}
