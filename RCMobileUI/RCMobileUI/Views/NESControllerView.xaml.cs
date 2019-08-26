using RCMobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCMobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NESControllerView : ContentView
    {
        public NESControllerView()
        {
            InitializeComponent();

            this.BindingContext = new NESControllerViewModel();
        }
    }
}