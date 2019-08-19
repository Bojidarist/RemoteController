using RCDesktopUI.Helpers;
using RCDesktopUI.Models.DataModels;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="ControlsConfigPage"/>
    /// </summary>
    public class ControlsConfigViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The current selected controller
        /// </summary>
        public ApplicationPage CurrentController { get; set; } = ApplicationPage.NESControllerPage;

        /// <summary>
        /// The visibility of the alert (0 = Collapsed, 1 = Hidden, 2 = Visible)
        /// </summary>
        public int AlertVisibility { get; set; } = 0;

        #endregion

        #region Commands

        /// <summary>
        /// This command is executed when the ResetControllerSettings button is clicked
        /// </summary>
        public ICommand ResetControllerSettingsCommand { get; set; }

        /// <summary>
        /// This command is executed when the RemoveAlert button is clicked
        /// </summary>
        public ICommand RemoveAlertCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControlsConfigViewModel()
        {
            this.MakeCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Make the necessary commands
        /// </summary>
        private void MakeCommands()
        {
            this.ResetControllerSettingsCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    switch (CurrentController)
                    {
                        case ApplicationPage.NESControllerPage:
                            // Reset settings
                            NESHelpers.ResetNESKeySettings();
                            // Display alert
                            this.AlertVisibility = 2;
                            break;
                        default:
                            break;
                    }
                });
            });

            this.RemoveAlertCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    // Remove the alert
                    this.AlertVisibility = 0;
                });
            });
        }

        #endregion
    }
}
