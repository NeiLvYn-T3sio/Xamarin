using Android.Graphics.Drawables;
using Android.Widget;
using NeilvynSampleBlueprint.Mobile.App.Droid.Effects;
using NeilvynSampleBlueprint.Mobile.Xamarin.UI.CustomControls.Effects;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.ViewGroup;
using DatePicker = Android.Widget.DatePicker;

[assembly: ExportEffect(typeof(NoBorderPlatformEffect), nameof(NoBorderEffect))]
namespace NeilvynSampleBlueprint.Mobile.App.Droid.Effects
{
    public class NoBorderPlatformEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control is EditText || Control is PickerEditText)
                {
                    Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                }
                else if (Control is DatePicker || Control is Spinner)
                {
                    var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                    layoutParams.SetMargins(0, 0, 0, 0);

                    Control.Background = null;
                    Control.LayoutParameters = layoutParams;

                    if (Control is DatePicker datePicker)
                    {
                        datePicker.LayoutParameters = layoutParams;
                        datePicker.SetPadding(20, 0, 20, 0);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}