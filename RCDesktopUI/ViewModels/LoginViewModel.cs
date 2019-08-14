using RCDesktopUI.Properties;
using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using RCLib.Server;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
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
        public string CurrentIP { get; set; } = Settings.Default.LatestValidIP;

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

        /// <summary>
        /// The text used by the DetectIP button
        /// </summary>
        public string DetectIPButtonText { get; set; } = " Detect  IP ";

        /// <summary>
        /// The visibility for DetectIP button (0 = Collapsed, 1 = Hidden, 2 = Visible)
        /// </summary>
        public int DetectIPButtonVisibility { get; set; } = 2;

        /// <summary>
        /// The placeholder text used by IPBox
        /// </summary>
        public string IPBoxPlaceholderText { get; set; } = "Enter your IP here!";

        #endregion

        #region Commands

        /// <summary>
        /// The command that executes when the StartServer button is clicked
        /// </summary>
        public ICommand StartServerClickedCommand { get; set; }

        /// <summary>
        /// The command that executes when the DetectIP button is clicked
        /// </summary>
        public ICommand DetectIPClickedCommand { get; set; }

        /// <summary>
        /// The command that executes when the ResetLoginSettings button is clicked
        /// </summary>
        public ICommand ResetDefaultLoginSettingsCommand { get; set; }

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
            this.StartServerClickedCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonServerManager.SingleServerManager.IsServerStarted)
                    {
                        this.IsServerNotStarting = false;
                        SingletonServerManager.SingleServerManager.StopServer();
                        this.StartServerButtonText = "Start Server";
                        this.DetectIPButtonVisibility = 2;
                        this.IsServerNotStarting = true;
                        this.IsIPBoxEnabled = true;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(this.CurrentIP))
                        {
                            try
                            {
                                this.IsServerNotStarting = false;
                                this.IsIPBoxEnabled = false;
                                SingletonServerManager.SingleServerManager.PrivateIPAddress = this.CurrentIP;
                                SingletonServerManager.SingleServerManager.StartServer();
                                this.StartServerButtonText = "Stop Server";
                                this.DetectIPButtonVisibility = 0;

                                // Save the latest working ip address
                                Settings.Default.LatestValidIP = CurrentIP;
                                Settings.Default.Save();
                                this.IsServerNotStarting = true;
                            }
                            catch (FormatException)
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
                    }
                });
            });

            this.DetectIPClickedCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    try
                    {
                        this.IsServerNotStarting = false;
                        this.CurrentIP = SingletonServerManager.SingleServerManager.FindLocalIPv4(true);
                        this.IsServerNotStarting = true;
                    }
                    catch (NullReferenceException)
                    {
                        this.CurrentIP = "IP not found";
                    }
                    finally
                    {
                        InitialChecks();
                    }
                });
            });

            this.ResetDefaultLoginSettingsCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    // Reset login settings
                    Settings.Default.LatestValidIP = "";
                    Settings.Default.Save();
                    this.CurrentIP = Settings.Default.LatestValidIP;
                });
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
                this.DetectIPButtonVisibility = 0;
            }
            else
            {
                this.IsIPBoxEnabled = true;
                this.StartServerButtonText = "Start Server";
                this.IsServerNotStarting = true;
                this.DetectIPButtonVisibility = 2;
            }
        }

        #endregion
    }
}
