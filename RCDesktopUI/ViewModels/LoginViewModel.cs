using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using RCLib.Server;
using System;
using System.Net.Sockets;
using System.Windows.Input;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="LoginPage"/>
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The current ip from the singleton <see cref="ServerManager"/>
        /// </summary>
        public string CurrentIP { get; set; } = SingletonServerManager.SingleServerManager.PrivateIPAddress;

        /// <summary>
        /// A boolean that indicates if the program is not currently starting a server
        /// </summary>
        public bool IsServerNotStarting { get; set; } = true;

        /// <summary>
        /// Indicates if the IP textbox is enabled
        /// </summary>
        public bool IsIPBoxEnabled { get; set; } = true;

        /// <summary>
        /// The text used by the StartServer button
        /// </summary>
        public string StartServerButtonText { get; set; } = "Start Server";

        #endregion

        #region Commands

        /// <summary>
        /// The command that executes when the StartServer button is clicked
        /// </summary>
        public ICommand StartServerClickedCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            this.MakeCommands();
            this.InitialChecks();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method for making all the commands used in the current view model.
        /// </summary>
        private void MakeCommands()
        {
            this.StartServerClickedCommand = new RelayCommand(() =>
            {
                if (SingletonServerManager.SingleServerManager.IsServerStarted)
                {
                    this.IsServerNotStarting = false;
                    SingletonServerManager.SingleServerManager.StopServer();
                    this.StartServerButtonText = "Start Server";
                    this.IsServerNotStarting = true;
                    this.IsIPBoxEnabled = true;
                }
                else
                {
                    try
                    {
                        this.IsServerNotStarting = false;
                        this.IsIPBoxEnabled = false;
                        SingletonServerManager.SingleServerManager.PrivateIPAddress = this.CurrentIP;
                        SingletonServerManager.SingleServerManager.StartServer();
                        this.StartServerButtonText = "Stop Server";
                        this.IsServerNotStarting = true;
                    }
                    catch(FormatException)
                    {
                        this.CurrentIP = "Invalid IP Address";
                    }
                    catch (SocketException)
                    {
                        this.CurrentIP = "Invalid IP Address";
                    }
                    finally
                    {
                        this.InitialChecks();
                    }
                }
            });
        }

        /// <summary>
        /// All initial checks when the view model is loaded
        /// </summary>
        private void InitialChecks()
        {
            if (SingletonServerManager.SingleServerManager.IsServerStarted)
            {
                this.IsIPBoxEnabled = false;
                this.StartServerButtonText = "Stop Server";
                this.IsServerNotStarting = true;
            }
            else
            {
                this.IsIPBoxEnabled = true;
                this.StartServerButtonText = "Start Server";
                this.IsServerNotStarting = true;
            }
        }

        #endregion
    }
}
