using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCMobileUI.ValueConverters
{
    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : IMarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private members

        /// <summary>
        /// Instance of the value converter 
        /// </summary>
        private static T mConverter = null;

        #endregion

        #region Value converter methods

        /// <summary>
        /// The method to convert one value to another
        /// </summary>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// The method to convert one value to it's original type
        /// </summary>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion

        #region Markup extension methods

        /// <summary>
        /// Provides a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #endregion
    }
}
