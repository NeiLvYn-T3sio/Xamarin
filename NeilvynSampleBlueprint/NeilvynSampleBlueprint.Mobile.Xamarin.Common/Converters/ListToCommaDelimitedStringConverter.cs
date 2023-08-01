using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters
{
    public class ListToCommaDelimitedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<object> list)
            {
                return string.Join(", ", list.Select(x => x.ToString())).Trim();
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
