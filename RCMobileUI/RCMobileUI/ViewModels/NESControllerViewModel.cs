using RCMobileUI.Utils;
using RCMobileUI.Views;

namespace RCMobileUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="NESControllerView"/>
    /// </summary>
    public class NESControllerViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// <see cref="ButtonHandler"/> stores all NES buttons
        /// </summary>
        public NESButtonHandler ButtonHandler { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NESControllerViewModel()
        {
            this.ButtonHandler = new NESButtonHandler();
        }

        #endregion
    }
}
