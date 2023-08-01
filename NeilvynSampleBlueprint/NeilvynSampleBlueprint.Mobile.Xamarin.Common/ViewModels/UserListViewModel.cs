using NeilvynSampleBlueprint.Mobile.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Common.Extensions;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private bool _isOfflineData;
        private readonly INavigationService _navigationService;
        private readonly IAppDialogService _appDialogService;
        private readonly IUserService _userService;
        private readonly ILogger<UserListViewModel> _logger;

        public ObservableCollection<UserItemModel> UserList { get; }

        public AsyncCommand BackCommand { get; }

        public UserListViewModel(
            INavigationService navigationService,
            IAppDialogService appDialogService,
            IUserService userService,
            ILogger<UserListViewModel> logger)
        {
            _navigationService = navigationService;
            _appDialogService = appDialogService;
            _userService = userService;
            _logger = logger;
            UserList = new ObservableCollection<UserItemModel>();
            BackCommand = new AsyncCommand(NavigateBack, allowsMultipleExecutions: false);
        }

        public override async Task InitializeAsync(object param)
        {
            try
            {
                await _appDialogService.ShowLoading("Loading User List...");

                IsOfflineData = false;

                var users = await _userService.GetUsers();

                UserList.AddRange(users.Select(x => new UserItemModel(x)));
                
                _logger.LogInformation("Loaded users {@users}", users);
            }
            catch (Exception ex)
            {
                if (ex is NoInternetConnectivityException)
                {
                    var usersDb = await _userService.GetUsersFromDb();

                    UserList.AddRange(usersDb.Select(x => new UserItemModel(x)));

                    IsOfflineData = true;
                }
                else
                {
                    _logger.LogWarning("Failed loading users {@ex}", ex);
                    await _appDialogService.ShowWarning(ex.Message);
                }
            }
            finally
            {
                await _appDialogService.HideLoading();
            }
        }

        private async Task NavigateBack()
        {
            await _navigationService.PopAsync();
        }

        public bool IsOfflineData
        {
            get => _isOfflineData;
            set => SetProperty(ref _isOfflineData, value);
        }
    }
}
