using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.CustomControls
{
    [ExcludeFromCodeCoverage]
    public class NullableTimePicker: TimePicker
    {
        public static readonly BindableProperty SelectedTimeProperty
            = BindableProperty.Create(nameof(SelectedTime), typeof(TimeSpan?), typeof(NullableTimePicker), null, BindingMode.TwoWay);

        public TimeSpan? SelectedTime
        {
            get => (TimeSpan?)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == TimeProperty.PropertyName || (propertyName == IsFocusedProperty.PropertyName && !IsFocused && Time == default))
            {
                SelectedTime = Time;
            }

            if (propertyName == SelectedTimeProperty.PropertyName && SelectedTime.HasValue)
            {
                Time = SelectedTime.Value;
            }
        }
    }
}