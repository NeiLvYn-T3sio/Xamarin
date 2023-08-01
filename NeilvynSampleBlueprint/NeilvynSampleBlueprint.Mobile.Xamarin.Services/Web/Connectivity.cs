using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Essentials;
using Essentials = Xamarin.Essentials;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web
{
    [ExcludeFromCodeCoverage]
    public class Connectivity : IConnectivity
    {
        public bool IsInternetConnected => Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
