using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;

        public AsyncCommand GoToUserListCommand { get; }
        public AsyncCommand GoToLoginCommand { get; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToUserListCommand = new AsyncCommand(GoToUserList, allowsMultipleExecutions: false);
            GoToLoginCommand = new AsyncCommand(GoToLogin, allowsMultipleExecutions: false);
        }

        private async Task GoToUserList()
        {
            await _navigationService.PushAsync(ViewNames.UserListPage);
        }

        private async Task GoToLogin()
        {
            await _navigationService.PushAsync(ViewNames.LoginPage);
        }
    }
}
