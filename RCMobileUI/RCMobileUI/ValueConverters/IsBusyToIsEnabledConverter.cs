using System;
using System.Globalization;

namespace RCMobileUI.ValueConverters
{
    public class IsBusyToIsEnabledConverter : BaseValueConverter<IsBusyToIsEnabledConverter>
    {
        /// <summary>
        /// Converts an IsBusy boolean to IsEnabled
        /// </summary>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return false;
            }
            else
            {
                return true;
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
