using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IPageResolver _pageResolver;
        private readonly ITaskRunner _taskRunner;
        private readonly ILogger<NavigationService> _logger;
        private IMainPage _rootNavigation;

        private INavigation Navigator => _rootNavigation.MainPage.Navigation;

        public NavigationService(
            IPageResolver pageResolver,
            ITaskRunner taskRunner,
            ILogger<NavigationService> logger,
            IMainPage rootNavigation)
        {
            _pageResolver = pageResolver;
            _taskRunner = taskRunner;
            _logger = logger;
            _rootNavigation = rootNavigation;
        }

        public async Task PushAsync(string viewName)
        {
            try
            {
                Page page = null;

                await _taskRunner.RunMainThreadAsync(() =>
                {
                    page = _pageResolver.GetPageWithAttachedViewModel(viewName);
                });

                if (page == null || _rootNavigation == null)
                {
                    return;
                }

                await _taskRunner.RunMainThreadAsync(async () => await Navigator.PushAsync(page));
            }
            catch (PageNotYetImplementedException ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogWarning("Page not implemented {@ex}", ex);
                throw ex;
            }
        }

        public async Task PushToNewRootPage(string viewName)
        {
            try
            {
                Page newRoot = null;

                _taskRunner.DeviceRunMainThread(() =>
                {
                    newRoot = _pageResolver.GetPageWithAttachedViewModel(viewName);
                });

                if (newRoot == null)
                {
                    return;
                }

                if (_rootNavigation?.MainPage == null)
                {
                    _rootNavigation.MainPage = new NavigationPage(newRoot);
                }
                else
                {
                    await _taskRunner.RunMainThreadAsync(() => Navigator.InsertPageBefore(newRoot, _rootNavigation.MainPage));
                    await _taskRunner.RunMainThreadAsync(() => Navigator.PopToRootAsync());
                }
            }
            catch (PageNotYetImplementedException ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogWarning("Page not implemented {@ex}", ex);
                throw ex;
            }
        }

        public async Task PopAsync()
        {
            await Navigator.PopAsync();
        }

        public async Task NavigateBack(Func<Task<bool>> confirmationHandler)
        {
            if (await confirmationHandler())
            {
                await this.PopAsync();
            }
        }
    }
}
