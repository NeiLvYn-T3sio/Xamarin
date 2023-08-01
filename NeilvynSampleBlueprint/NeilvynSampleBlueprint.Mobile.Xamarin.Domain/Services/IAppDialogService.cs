using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services
{
    public interface IAppDialogService
    {
        Task<bool> ShowConfirmAsync(string message, string confirm);
        Task<bool> ShowConfirmAsync(string message, string title, string confirm);
        Task<bool> ShowConfirmAsync(string message, string title, string confirm, string cancel);
        Task ShowLoading(string title = null);
        Task HideLoading();
        Task ShowWarning(string message);
        Task ShowWarning(string message, string title);
        Task ShowPopupPage(string popupName, object param, bool isAnimated = true);
        Task ClosePopupPage();
    }
}
