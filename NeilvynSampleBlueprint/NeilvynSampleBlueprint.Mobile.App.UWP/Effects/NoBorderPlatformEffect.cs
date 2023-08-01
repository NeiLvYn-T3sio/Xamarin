using System;
using NeilvynSampleBlueprint.Mobile.App.Forms.CustomControls.Effects;
using NeilvynSampleBlueprint.Mobile.App.UWP.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Thickness = Windows.UI.Xaml.Thickness;

[assembly: ExportEffect(typeof(NoBorderPlatformEffect), nameof(NoBorderEffect))]
namespace NeilvynSampleBlueprint.Mobile.App.UWP.Effects
{
    public class NoBorderPlatformEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is FormsTextBox textBox)
            {
                textBox.BorderThickness = new Thickness(0);
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}
