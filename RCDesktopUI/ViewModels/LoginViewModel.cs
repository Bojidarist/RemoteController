using RCDesktopUI.Properties;
using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using RCLib.Server;
using System;
using System.Drawing;
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

        /// <summary>
        /// The text that will appear when info occurs
        /// </summary>
        public string InfoText { get; set; }

        /// <summary>
        /// The visibility for the InfoText (0 = Collapsed, 1 = Hidden, 2 = Visible)
        /// </summary>
        public int InfoTextVisibility { get; set; } = 0;

        /// <summary>
        /// The foreground color for InfoText
        /// </summary>
        public string InfoTextForegroundColorRGB { get; set; } = "ff1744";

        /// <summary>
        /// The QR code containing the IP of the server
        /// </summary>
        public Image LoginQR { get; set; }

        /// <summary>
        /// The visibility for LoginQR (0 = Collapsed, 1 = Hidden, 2 = Visible)
        /// </summary>
        public int LoginQRVisibility { get; set; } = 0;

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

        /// <summary>
        /// The command that executes when the info text is clicked
        /// </summary>
        public ICommand ResetInfoTextCommand { get; set; }

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
        /// Method for making all the commands used in the current view model
        /// </summary>
        private void MakeCommands()
        {
            this.StartServerClickedCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonServerManager.SingleServerManager.IsServerStarted)
                    {
                        // If the server is already started then stop it
                        this.IsServerNotStarting = false;
                        SingletonServerManager.SingleServerManager.StopServer();
                        this.StartServerButtonText = "Start Server";
                        this.DetectIPButtonVisibility = 2;
                        this.InfoMessage("Waiting For Connection", false, "0288d1");

                        // Collapse the QR code
                        this.LoginQRVisibility = 0;

                        this.IsServerNotStarting = true;
                        this.IsIPBoxEnabled = true;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(this.CurrentIP))
                        {
                            try
                            {
                                // If the server is not started then start it
                                this.IsServerNotStarting = false;
                                this.IsIPBoxEnabled = false;
                                SingletonServerManager.SingleServerManager.PrivateIPAddress = this.CurrentIP;
                                SingletonServerManager.SingleServerManager.StartServer();
                                this.StartServerButtonText = "Stop Server";
                                this.DetectIPButtonVisibility = 0;

                                // Save the latest working ip address
                                Settings.Default.LatestValidIP = CurrentIP;
                                Settings.Default.Save();

                                // Remove the info message if there is one
                                this.InfoMessage("Waiting For Connection", true, "0288d1");

                                // Display the QR code 
                                this.LoginQR = Helpers.Utils.QRCodeGenerator.Generate(this.CurrentIP, 50);
                                this.LoginQRVisibility = 2;

                                this.IsServerNotStarting = true;
                            }
                            catch (FormatException)
                            {
                                this.InfoMessage("Invalid IP Address", true, "ff1744");
                            }
                            catch (SocketException)
                            {
                                this.InfoMessage("Invalid IP Address", true, "ff1744");
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
                        // Try to find the local IPv4 address. If it cannot be found then display error
                        this.IsServerNotStarting = false;
                        this.CurrentIP = SingletonServerManager.SingleServerManager.FindLocalIPv4(true);
                        this.IsServerNotStarting = true;
                    }
                    catch (NullReferenceException)
                    {
                        this.InfoMessage("IP Not Found", true, "ff1744");
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

            this.ResetInfoTextCommand = new RelayCommand(async () =>
            {
                await Task.Run(() =>
                {
                    // Remove the info message
                    this.InfoMessage("", false, "ff1744");
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
                this.InfoMessage("Waiting For Connection", true, "0288d1");

                // Display the QR code 
                this.LoginQR = Helpers.Utils.QRCodeGenerator.Generate(this.CurrentIP, 50);
                this.LoginQRVisibility = 2;
            }
            else
            {
                this.IsIPBoxEnabled = true;
                this.StartServerButtonText = "Start Server";
                this.IsServerNotStarting = true;
                this.DetectIPButtonVisibility = 2;

                // Collapse the QR code
                this.LoginQRVisibility = 0;
            }
        }

        /// <summary>
        /// Displays an info message in the login screen
        /// </summary>
        /// <param name="infoMessage">The info message</param>
        /// <param name="messageColor">The color of the message in hex</param>
        /// <param name="isActive">Determines if the info message will be visible</param>
        private void InfoMessage(string infoMessage, bool isActive, string messageColor)
        {
            // Set the info message
            this.InfoText = infoMessage;
            if (isActive)
            {
                // Make the info message visible
                this.InfoTextVisibility = 2;
                this.InfoTextForegroundColorRGB = messageColor;
            }
            else
            {
                // Collapse the info message
                this.InfoTextVisibility = 0;
                this.InfoTextForegroundColorRGB = messageColor;
            }
        }

        #endregion
    }
}
