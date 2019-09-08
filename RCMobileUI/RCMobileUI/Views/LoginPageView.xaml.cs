using RCMobileUI.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace RCMobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageView : ContentView
    {
        private LoginPageViewModel Model { get; set; } = new LoginPageViewModel();

        public LoginPageView()
        {
            InitializeComponent();

            Init();
            this.BindingContext = Model;
        }

        /// <summary>
        /// Initializes stuff
        /// </summary>
        private void Init()
        {
            // Initialize QRScanCommand
            Model.QRScanCommand = new Command(async () =>
            {
                Model.IsBusy = true;
                await QRScanner();
                Model.IsBusy = false;
            });
        }

        /// <summary>
        /// Opens up the QR/Barcode scanner and sets the model's IPBox
        /// </summary>
        private async Task QRScanner()
        {
            // Setup options
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                TryHarder = true,
            };

            // Add options and customize page
            var scanPage = new ZXingScannerPage(options)
            {
                DefaultOverlayTopText = "Align the barcode within the frame",
                DefaultOverlayBottomText = string.Empty,
                DefaultOverlayShowFlashButton = true
            };

            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;
                Model.IPBoxText = result.Text;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                });
            };

            NavigationPage.SetHasNavigationBar(scanPage, false);

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }
    }
}