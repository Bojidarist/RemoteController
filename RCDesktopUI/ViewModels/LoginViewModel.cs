using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;
using RCLib.Server;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="LoginPage"/>
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// The current ip from the singleton <see cref="ServerManager"/>
        /// </summary>
        public string CurrentIP { get; set; } = SingletonServerManager.SingleServerManager.PrivateIPAddress;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
        }
    }
}
