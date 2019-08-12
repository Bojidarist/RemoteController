using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using RCLib.Server;
using System.Threading;
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
        public string CurrentIP { get; set; } = SingletonServerManager.SingleServerManager.PrivateIPAddress;

        /// <summary>
        /// A boolean that indicates if the program is not currently starting a server
        /// </summary>
        public bool IsNotStartingServer { get; set; } = true;

        public string StartServerButtonText { get; set; } = "Start Server";

        #endregion

        #region Commands

        public ICommand StartServerClickedCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            this.MakeCommands();
        }

        #endregion

        #region Methods

        private void MakeCommands()
        {
            this.StartServerClickedCommand = new RelayCommand(() =>
            {
                this.IsNotStartingServer = false;
                SingletonServerManager.SingleServerManager.PrivateIPAddress = this.CurrentIP;
                SingletonServerManager.SingleServerManager.StartServer();
                this.StartServerButtonText = "Started";
            });
        }

        #endregion
    }
}
