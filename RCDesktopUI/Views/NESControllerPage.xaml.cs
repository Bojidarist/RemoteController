using RCDesktopUI.ViewModels;
using System.Windows.Controls;

namespace RCDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for NESControllerPage.xaml
    /// </summary>
    public partial class NESControllerPage : Page
    {
        public NESControllerPage()
        {
            InitializeComponent();

            this.DataContext = new NESControllerViewModel();
        }
    }
}
