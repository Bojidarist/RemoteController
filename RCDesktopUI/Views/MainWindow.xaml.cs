using RCDesktopUI.ViewModels;
using System.Windows;

namespace RCDesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// This event fires when the main window is closing
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Cleanup
            Server.SingletonServerManager.SingleServerManager.StopServer();
        }
    }
}
