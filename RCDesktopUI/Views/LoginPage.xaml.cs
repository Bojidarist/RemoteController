using RCDesktopUI.ViewModels;
using System.Windows.Controls;

namespace RCDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel();
        }
    }
}
