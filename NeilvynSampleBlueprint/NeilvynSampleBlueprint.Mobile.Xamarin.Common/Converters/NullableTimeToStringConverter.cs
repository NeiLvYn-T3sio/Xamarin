using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters
{
    [ExcludeFromCodeCoverage]
    public class NullableTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan valTime)
            {
                return $"{valTime}";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string valString && !string.IsNullOrEmpty(valString) &&
                TimeSpan.TryParse(valString, out var valTime))
            {
                return valTime;
            }

            return null;
        }
    }
}