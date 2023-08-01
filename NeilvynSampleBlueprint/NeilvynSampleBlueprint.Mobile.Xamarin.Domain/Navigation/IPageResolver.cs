using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation
{
    public interface IPageResolver
    {
        Page GetPageWithAttachedViewModel(string viewName);
        DialogBase GetPopupPageWithAttachedViewModel(string popupName);
    }
}