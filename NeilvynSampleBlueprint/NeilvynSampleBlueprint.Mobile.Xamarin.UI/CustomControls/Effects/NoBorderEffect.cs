using System.Diagnostics.CodeAnalysis;
using NeilvynSampleBlueprint.Mobile.Common.Constants;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.CustomControls.Effects
{
    [ExcludeFromCodeCoverage]
    public class NoBorderEffect : RoutingEffect
    {
        public NoBorderEffect() : base($"{AppConstants.EffectsNamespace}.{nameof(NoBorderEffect)}")
        {

        }
    }
}
