using RCDesktopUI.Models.DataModels;
using RCDesktopUI.ViewModels.Base;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="MainWindow"/>
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The current page that is loaded
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// The title of the current window
        /// </summary>
        public string WindowTitle { get; set; } = "RemoteController";

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {

        }

        #endregion
    }
}
