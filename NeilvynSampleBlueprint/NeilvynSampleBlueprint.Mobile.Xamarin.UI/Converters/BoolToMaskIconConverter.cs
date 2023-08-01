using NeilvynSampleBlueprint.Mobile.Xamarin.UI.Resources;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.Converters
{
    public class BoolToMaskIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valBool)
            {
                return valBool ? FontAwesomeIcons.EyeSlash : FontAwesomeIcons.Eye;
            }

            return FontAwesomeIcons.EyeSlash;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string valString)
            {
                return valString == FontAwesomeIcons.EyeSlash;
            }

            return true;
        }
    }
}
