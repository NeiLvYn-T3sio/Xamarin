using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation
{
    /// <remarks>
    /// This interface is used in the App class to allow the NavigationService to set the main page
    /// </remarks>
    public interface IMainPage
    {
        Page MainPage { get; set; }
    }
}
