
using RCMobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCMobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllerSelectView : ContentView
    {
        public ControllerSelectView()
        {
            InitializeComponent();

            this.BindingContext = new ControllerSelectViewModel();
        }
    }
}