using System;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation
{
    public interface INavigationService
    {
        Task PushAsync(string viewName);
        Task PushToNewRootPage(string viewName);
        Task PopAsync();
        Task NavigateBack(Func<Task<bool>> confirmationHandler);
    }
}