using System.Windows;
using System.Threading;
using System;
using System.IO;
using System.Runtime.ExceptionServices;

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
            // Close this instance another instance of the app is running
            SingleInstaceCheck();

            // Log all exceptions
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceExceptionHandler;

            base.OnStartup(e);
        }

        /// <summary>
        /// Close this instance another instance of the app is running
        /// </summary>
        private void SingleInstaceCheck()
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
        }

        /// <summary>
        /// Log exceptions when they are thrown
        /// </summary>
        private void FirstChanceExceptionHandler(object sender, FirstChanceExceptionEventArgs e)
        {
            bool fileExists = File.Exists("Log.txt");
            using (StreamWriter writer = new StreamWriter("Log.txt", true))
            {
                if (fileExists)
                {
                    writer.WriteLine();
                }
                writer.WriteLine($"(UTC){ DateTime.UtcNow }: { e.Exception.GetType() } From { e.Exception.Source }");
                writer.WriteLine($"Message: { e.Exception.Message }");
                writer.WriteLine($"StackTrace: { e.Exception.StackTrace }");
                writer.WriteLine($"Data: { e.Exception.Data }");
                writer.WriteLine($"HelpLink: { e.Exception.HelpLink }");
                writer.WriteLine($"HResult: { e.Exception.HResult }");
            }
        }
    }
}
