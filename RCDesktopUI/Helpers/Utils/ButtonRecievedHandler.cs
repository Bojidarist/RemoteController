using RCDesktopUI.Server;
using RCLib.Models;
using System.Threading.Tasks;

namespace RCDesktopUI.Helpers
{
    public class ButtonRecievedHandler
    {
        /// <summary>
        /// Default constructor
        /// <paramref name="subscribe">Indicates if automatic subscription is made</paramref>
        /// </summary>
        public ButtonRecievedHandler(bool subscribe = true)
        {
            if (subscribe)
            {
                this.SubscribeToServerDataReceived();
            }
        }

        /// <summary>
        /// Subscribe to ServerDataReceived event
        /// </summary>
        public void SubscribeToServerDataReceived()
        {
            SingletonServerManager.SingleServerManager.ServerDataReceived += SingleServerManager_ServerDataReceived;
        }

        /// <summary>
        /// Unsubscribe from ServerDataReceived event
        /// </summary>
        public void UnsubscribeFromServerDataReceived()
        {
            SingletonServerManager.SingleServerManager.ServerDataReceived -= SingleServerManager_ServerDataReceived;
        }

        /// <summary>
        /// The event handler
        /// </summary>
        /// <param name="sender">The server that sent this</param>
        /// <param name="e">The button that is sent</param>
        private void SingleServerManager_ServerDataReceived(object sender, ConsoleButtonEventArgs e)
        {
            Task.Run(() =>
            {
                switch (e.ConsoleButton.ConsoleName)
                {
                    case ConsoleNameEnum.NONE:
                        break;
                    case ConsoleNameEnum.NES:
                        NESHelpers.NESKeyEvent(e.ConsoleButton.KeyName, e.ConsoleButton.KeyState);
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
