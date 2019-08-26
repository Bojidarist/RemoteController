
using RCMobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCMobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageView : ContentView
    {
        public LoginPageView()
        {
            InitializeComponent();

            this.BindingContext = new LoginPageViewModel();
        }
    }
}