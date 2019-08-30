using RCMobileUI.Helpers;
using RCMobileUI.Views;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RCMobileUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="LoginPageView"/>
    /// </summary>
    public class LoginPageViewModel : BaseViewModel
    {
        #region Private members

        private string mIPBoxText = "";

        #endregion

        #region Public properties

        /// <summary>
        /// The text in the box where you enter the IP
        /// </summary>
        public string IPBoxText
        {
            get
            {
                return this.mIPBoxText;
            }
            set
            {
                this.mIPBoxText = value;
                this.OnPropertyChanged(nameof(IPBoxText));
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Fires when the DetectIP button is clicked
        /// </summary>
        public Command DetectIPButtonClicked { get; set; }

        /// <summary>
        /// Fires when the Connect button is clicked
        /// </summary>
        public Command ConnectButtonClicked { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPageViewModel()
        {
            this.InitialChecks();
            this.MakeCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Make the commands needed for this view model
        /// </summary>
        private void MakeCommands()
        {
            this.DetectIPButtonClicked = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    this.IsBusy = true;
                    this.IPBoxText = Client.SingletonRCClient.SingleRCClient.GetActiveServerIP();
                    this.IsBusy = false;
                });
            });

            this.ConnectButtonClicked = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (!String.IsNullOrWhiteSpace(this.IPBoxText))
                    {
                        this.IsBusy = true;
                        try
                        {
                            if (RCClientHelpers.PingServer(this.IPBoxText, RCClientHelpers.ServerPort, 200))
                            {
                                Client.SingletonRCClient.SingleRCClient.Connect(this.IPBoxText, RCClientHelpers.ServerPort);
                                RCClientHelpers.LatestIPAddress = this.IPBoxText;
                            }
                        }
                        catch (SocketException)
                        {
                            // Display info message
                        }
                        finally
                        {
                            this.IsBusy = false;
                        }
                    }
                });
            });
        }

        private void InitialChecks()
        {
            this.IPBoxText = RCClientHelpers.LatestIPAddress;
        }

        #endregion
    }
}
