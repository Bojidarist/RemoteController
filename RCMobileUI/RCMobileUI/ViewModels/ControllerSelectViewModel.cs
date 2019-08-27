using RCMobileUI.Models.DataModels;
using RCMobileUI.Views;

namespace RCMobileUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="ControllerSelectView"/>
    /// </summary>
    public class ControllerSelectViewModel : BaseViewModel
    {
        #region Private members

        private ApplicationPage mCurrentController = ApplicationPage.NESControllerView;

        #endregion

        #region Public properties

        /// <summary>
        /// The current selected controller
        /// </summary>
        public ApplicationPage CurrentController
        {
            get
            {
                return this.mCurrentController;
            }
            set
            {
                this.mCurrentController = value;
                this.OnPropertyChanged(nameof(CurrentController));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerSelectViewModel()
        {
        }

        #endregion
    }
}
