using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Essentials;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services
{
    [ExcludeFromCodeCoverage]
    public class AppInformationService : IAppInformationService
    {
        public string GetReleaseVersion()
        {
            return AppInfo.VersionString;
        }

        public string GetApplicationName()
        {
            return AppInfo.Name;
        }
    }
}
