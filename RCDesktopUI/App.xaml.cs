using System.Windows;
using System.Threading;
using System;

namespace RCDesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex = null;

        /// <summary>
        /// This is executed when the process starts
        /// </summary>
        /// <param name="e">Startup arguments</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Get the name of the current app
            string appName = AppDomain.CurrentDomain.FriendlyName;
            bool isNew;

            _mutex = new Mutex(true, appName, out isNew);

            if (!isNew)
            {
                // If the app is already running then exit
                Application.Current.Shutdown();
            }

            base.OnStartup(e);
        }
    }
}
