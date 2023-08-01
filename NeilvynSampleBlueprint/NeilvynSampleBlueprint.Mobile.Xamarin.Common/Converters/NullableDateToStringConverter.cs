using System;
using System.Globalization;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters
{
    public class NullableDateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime valDateTime)
            {
                return $"{valDateTime}";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string valString && !string.IsNullOrEmpty(valString) &&
                DateTime.TryParse(valString, out var valDate))
            {
                return valDate;
            }

            return null;
        }
    }
}
