using NeilvynSampleBlueprint.Mobile.Xamarin.Domain;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters
{
    public class PickerValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case IEmpty _:
                case string valString when valString == "[empty]":
                    return string.Empty;
                default:
                    return value != null ? value.ToString() : string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
