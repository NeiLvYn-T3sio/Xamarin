using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.CustomControls
{
    [ExcludeFromCodeCoverage]
    public class NullableDatePicker : DatePicker
    {
        public static readonly BindableProperty SelectedDateProperty
            = BindableProperty.Create(nameof(SelectedDate), typeof(DateTime?), typeof(NullableDatePicker), null, BindingMode.TwoWay);

        public DateTime? SelectedDate
        {
            get => (DateTime?)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == DateProperty.PropertyName || (propertyName == IsFocusedProperty.PropertyName && !IsFocused && Date == DateTime.Now.Date))
            {
                SelectedDate = Date;
            }

            if (propertyName == SelectedDateProperty.PropertyName && SelectedDate.HasValue)
            {
                Date = SelectedDate.Value;
            }
        }
    }
}
