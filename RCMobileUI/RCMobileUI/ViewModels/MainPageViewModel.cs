using RCMobileUI.Helpers;
using RCMobileUI.Models.DataModels;
using RCMobileUI.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

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
                if (!(value == mCurrentPage))
                {
                    this.mCurrentPage = value;
                    this.OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPageViewModel()
        {
            this.StartConnectionListener(500, 420);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if the client is connected to a server
        /// </summary>
        /// <param name="delayBetweenCheck">The delay between every check in milliseconds</param>
        /// <param name="waitTime">The time needed for every ping to the server in milliseconds</param>
        public void StartConnectionListener(int delayBetweenCheck = 1000, int waitTime = 100)
        {
            // Make the command
            Command connectionChecker = new Command(async () =>
            {
                while (true)
                {
                    if (RCClientHelpers.PingServer(RCClientHelpers.LatestIPAddress, RCClientHelpers.ServerPort, waitTime))
                    {
                        if (Client.SingletonRCClient.SingleRCClient.IsConnected)
                        {
                            this.CurrentPage = ApplicationPage.ControllerSelect;
                        }
                    }
                    else
                    {
                        this.CurrentPage = ApplicationPage.Login;
                        Client.SingletonRCClient.SingleRCClient.TcpClient.Disconnect();
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
