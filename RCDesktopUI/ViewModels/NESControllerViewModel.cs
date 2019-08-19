using RCDesktopUI.Helpers;
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
        #region Public properties

        /// <summary>
        /// A list of keys
        /// </summary>
        public ObservableCollection<string> KeyboardKeys { get; set; }

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
