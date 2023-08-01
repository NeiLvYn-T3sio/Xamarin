namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services
{
    public interface IAppInformationService
    {
        string GetReleaseVersion();
        string GetApplicationName();
    }
}