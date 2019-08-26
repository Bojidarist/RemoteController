using RCMobileUI.Models.DataModels;
using RCMobileUI.Views;
using System;
using System.Diagnostics;
using System.Globalization;

namespace RCMobileUI.ValueConverters
{
    public class ApplicationPageConverter : BaseValueConverter<ApplicationPageConverter>
    {
        /// <summary>
        /// Converts the <see cref="ApplicationPage"/> to an actual page
        /// </summary>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the requested page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.None:
                    return new NonePageView();
                case ApplicationPage.Login:
                    return new LoginPageView();
                case ApplicationPage.ControllerSelect:
                    return new ControllerSelectView();
                case ApplicationPage.NESControllerView:
                    return new NESControllerView();
                default:
                    // If a unknown page is requested stop the app and signal a breakpoint for debugging
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
