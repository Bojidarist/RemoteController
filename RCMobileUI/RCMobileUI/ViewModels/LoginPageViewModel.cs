using RCMobileUI.Helpers;
using RCMobileUI.Views;
using System;
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
            this.MakeCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Make the commands needed for this view model
        /// </summary>
        private void MakeCommands()
        {
            this.DetectIPButtonClicked = new Command(() =>
            {
                this.IPBoxText = Client.SingletonRCClient.SingleRCClient.GetActiveServerIP();
            });

            this.ConnectButtonClicked = new Command(() =>
            {
                if (!String.IsNullOrWhiteSpace(this.IPBoxText))
                {
                    Client.SingletonRCClient.SingleRCClient.Connect(this.IPBoxText, 8910);
                }
            });
        }

        #endregion
    }
}
