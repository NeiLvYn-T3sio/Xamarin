using System;
using System.Diagnostics;
using CoreGraphics;
using NeilvynSampleBlueprint.Mobile.App.Forms.CustomControls.Effects;
using NeilvynSampleBlueprint.Mobile.App.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(NoBorderPlatformEffect), nameof(NoBorderEffect))]
namespace NeilvynSampleBlueprint.Mobile.App.iOS.Effects
{
    public class NoBorderPlatformEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control != null)
                {
                    if (Control is UITextField textField)
                    {
                        textField.BorderStyle = UITextBorderStyle.None;
                    }
                    else if (Control is UIDatePicker || Control is UIPickerView)
                    {
                        Control.Layer.BorderWidth = 0;

                        if (Control is UITextField pickerTextField)
                        {
                            pickerTextField.BorderStyle = UITextBorderStyle.None;
                            UIView paddingView = new UIView(new CGRect(0.0f, 50.0f, 10.0f, 50.0f));
                            pickerTextField.LeftView = paddingView;
                            pickerTextField.LeftViewMode = UITextFieldViewMode.Always;
                            pickerTextField.RightView = paddingView;
                            pickerTextField.RightViewMode = UITextFieldViewMode.Always;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}