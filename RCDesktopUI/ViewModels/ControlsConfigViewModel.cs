using RCDesktopUI.Models.DataModels;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="ControlsConfigPage"/>
    /// </summary>
    public class ControlsConfigViewModel : BaseViewModel
    {
        /// <summary>
        /// The current selected controller
        /// </summary>
        public ApplicationPage CurrentController { get; set; } = ApplicationPage.NESControllerPage;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControlsConfigViewModel()
        {
        }
    }
}
