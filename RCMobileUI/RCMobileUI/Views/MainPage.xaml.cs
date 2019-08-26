﻿
using RCMobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCMobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainPageViewModel();
        }
    }
}