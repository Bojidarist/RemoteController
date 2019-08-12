using RCDesktopUI.Server;
using RCDesktopUI.ViewModels.Base;
using RCDesktopUI.Views;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="LoginPage"/>
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private string mCurrentIP = SingletonServerManager.SingleServerManager.PrivateIPAddress;
        public string CurrentIP
        {
            get
            {
                return mCurrentIP;
            }
            set
            {
                this.mCurrentIP = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
        }
    }
}
