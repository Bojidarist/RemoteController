using RCDesktopUI.ViewModels;
using System.Windows.Controls;

namespace RCDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ControlsConfigPage.xaml
    /// </summary>
    public partial class ControlsConfigPage : Page
    {
        public ControlsConfigPage()
        {
            InitializeComponent();

            this.DataContext = new ControlsConfigViewModel();
        }
    }
}
