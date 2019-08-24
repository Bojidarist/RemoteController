using System;
using System.Globalization;
using System.Windows.Media;

namespace RCDesktopUI.ValueConverters
{
    /// <summary>
    /// A converter that takes a RGB string (in hex) like 'ffffff' and converts it to a WPF brush
    /// </summary>
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{ value }"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}