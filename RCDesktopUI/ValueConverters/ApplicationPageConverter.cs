using RCDesktopUI.Models.DataModels;
using RCDesktopUI.Views;
using System;
using System.Diagnostics;
using System.Globalization;

namespace RCDesktopUI.ValueConverters
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
                    return new NonePage();
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.ControlsConfig:
                    return new ControlsConfigPage();
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
