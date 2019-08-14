using System;
using System.Globalization;
using System.Windows;

namespace RCDesktopUI.ValueConverters
{
    public class IntToVisibilityConverter : BaseValueConverter<IntToVisibilityConverter>
    {
        /// <summary>
        /// Converts integer value to visibility (0 = Collapsed, 1 = Hidden, 2 = Visible)
        /// </summary>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the requested visibility
            switch ((int)value)
            {
                case 0:
                    return Visibility.Collapsed;
                case 1:
                    return Visibility.Hidden;
                case 2:
                    return Visibility.Visible;
                default:
                    // Return collapsed as default
                    return Visibility.Collapsed;
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
