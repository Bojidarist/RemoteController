using RCDesktopUI.Models.DataModels;
using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

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

        /// <summary>
        /// The height of the current window
        /// </summary>
        public int WindowHeight { get; set; } = 800;

        /// <summary>
        /// The width of the current window
        /// </summary>
        public int WindowWidth { get; set; } = 1000;

        /// <summary>
        /// The minimal height of the current window
        /// </summary>
        public int MinWindowHeight { get; set; } = 600;

        /// <summary>
        /// The minimal width of the current window
        /// </summary>
        public int MinWindowWidth { get; set; } = 800;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {
            this.StartConnectionListener();
        }

        #endregion

        #region Methods

        /// <summary>
        /// When a user connects to the server change the <see cref="ApplicationPage"/>
        /// <paramref name="minConnections">The minimum connections needed for this to trigger</paramref>
        /// <paramref name="delayBetweenCheck">The delay between every check in milliseconds</paramref>
        /// </summary>
        public void StartConnectionListener(int minConnections = 1, int delayBetweenCheck = 1000)
        {
            // Make the command
            ICommand connectionChecker = new RelayCommand(async () =>
            {
                while (true)
                {
                    if (SingletonServerManager.SingleServerManager.ConnectedDevicesCount >= minConnections)
                    {
                        this.CurrentPage = ApplicationPage.ControlsConfig;
                    }
                    else
                    {
                        this.CurrentPage = ApplicationPage.Login;
                    }
                    await Task.Delay(delayBetweenCheck);
                }
            });

            // Start the listener
            connectionChecker.Execute(null);
        }

        #endregion
    }
}
