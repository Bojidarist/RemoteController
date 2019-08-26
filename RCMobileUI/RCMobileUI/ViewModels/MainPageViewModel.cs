using RCMobileUI.Models.DataModels;
using RCMobileUI.Views;

namespace RCMobileUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="MainPage"/>
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        #region Private members

        private ApplicationPage mCurrentPage = ApplicationPage.Login;

        #endregion

        #region Public properties

        /// <summary>
        /// The current selected page
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get
            {
                return this.mCurrentPage;
            }
            set
            {
                this.mCurrentPage = value;
                this.OnPropertyChanged(nameof(CurrentPage));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPageViewModel()
        {
            this.CurrentPage = ApplicationPage.Login;
        }

        #endregion
    }
}
