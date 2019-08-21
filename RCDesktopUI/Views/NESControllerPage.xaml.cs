using RCDesktopUI.Helpers;
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
            
            // Subscribe to event for when NES settings are reset
            NESHelpers.OnNESSettingsReset += NESHelpers_OnNESSettingsReset;

            this.DataContext = new NESControllerViewModel();
        }

        /// <summary>
        /// Reset all values ComboBox values when the settings are reset
        /// </summary>
        private void NESHelpers_OnNESSettingsReset(object sender, string e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.AButtonComboBox.SelectedValue = "";
                this.BButtonComboBox.SelectedValue = "";
                this.LeftButtonComboBox.SelectedValue = "";
                this.RightButtonComboBox.SelectedValue = "";
                this.UpButtonComboBox.SelectedValue = "";
                this.DownButtonComboBox.SelectedValue = "";
                this.SelectButtonComboBox.SelectedValue = "";
                this.StartButtonComboBox.SelectedValue = "";
            });
        }

        /// <summary>
        /// Unsubscribe from <see cref="NESHelpers.OnNESSettingsReset"/>
        /// when the page is unloaded to prevent memory leaks
        /// </summary>
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            NESHelpers.OnNESSettingsReset -= NESHelpers_OnNESSettingsReset;
        }
    }
}
