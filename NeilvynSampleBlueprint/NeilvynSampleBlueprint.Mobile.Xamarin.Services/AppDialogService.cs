using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Common.Localization;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.ViewModels;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services
{
    [ExcludeFromCodeCoverage]
    public class AppDialogService : IAppDialogService
    {
        private readonly IPageResolver _pageFactory;
        private readonly ITaskRunner _taskRunner;
        private readonly IPopupNavigation _popupNavigation;

        public AppDialogService(IPageResolver pageFactory, ITaskRunner taskRunner, IPopupNavigation popupNavigation)
        {
            _pageFactory = pageFactory;
            _taskRunner = taskRunner;
            _popupNavigation = popupNavigation;
        }

        public async Task ShowLoading(string title = null)
        {
            await CloseLoadingPage();

            var param = new LoadingDialogParam(title ?? AppResources.Label_Loading);

            await ShowPopupPage(ViewNames.LoadingDialog, param, false);
        }

        public async Task HideLoading()
        {
            await CloseLoadingPage();
        }

        private async Task CloseLoadingPage()
        {
            try
            {
                var loadings = _popupNavigation.PopupStack.OfType<DialogBase>().ToList();

                foreach (var currentPage in loadings)
                {
                    CleanUpPageViewModel(currentPage);

                    await _popupNavigation.RemovePageAsync(currentPage);
                }
            }
            catch (Exception ex)
            {
                await ShowWarning(ex.Message);
            }
        }

        public async Task ShowWarning(string message)
        {
            await ShowWarning(message, null);
        }

        public async Task ShowWarning(string message, string title)
        {
            var param = new AlertDialogParam(message, title, AppResources.Label_Close);

            await ShowPopupPage(ViewNames.AlertDialog, param, false);
        }

        public async Task<bool> ShowConfirmAsync(string message, string confirm)
        {
            return await ShowConfirmAsync(message, null, confirm);
        }

        public async Task<bool> ShowConfirmAsync(string message, string title, string confirm)
        {
            return await ShowConfirmAsync(message, title, confirm, AppResources.Label_Cancel);
        }
        
        public async Task<bool> ShowConfirmAsync(string message, string title, string confirm, string cancel)
        {
            var confirmFinished = new TaskCompletionSource<bool>();
            
            var confirmParam = new ConfirmDialogParam(message, title, confirm, cancel);

            confirmParam.ConfirmationCompleted += (sender, b) => { confirmFinished.TrySetResult(b); };
            
            await ShowPopupPage(ViewNames.ConfirmDialog, confirmParam, false);

            var result = await confirmFinished.Task;

            await ClosePopupPage();
            
            return result;
        }

        
        public async Task ShowPopupPage(string popupName, object param, bool isAnimated = true)
        {
            try
            {
                DialogBase page = null;

                await _taskRunner.RunMainThreadAsync(() =>
                {
                    page = _pageFactory.GetPopupPageWithAttachedViewModel(popupName);
                });

                if (page == null)
                {
                    return;
                }

                await _popupNavigation.PushAsync(page, isAnimated);
                
                await InitializePageViewModel(page, param);
            }
            catch (PageNotYetImplementedException ex)
            {
                await ShowWarning(ex.Message);
            }
        }

        public async Task ClosePopupPage()
        {
            try
            {
                var currentPage = _popupNavigation.PopupStack.First();
                
                CleanUpPageViewModel(currentPage);
                
                await _popupNavigation.PopAsync(false);
            }
            catch (Exception ex)
            {
                await ShowWarning(ex.Message);
            }
        }

        private async Task InitializePageViewModel(BindableObject page, object parameter)
        {
            if (page.BindingContext is IViewModel viewModel)
            {
                await viewModel.InitializeAsync(parameter);

                viewModel.Subscribe();
            }
        }
        
        private void  CleanUpPageViewModel(BindableObject p)
        {
            if (p.BindingContext is IViewModel viewModel)
            {
                viewModel.Unsubscribe();

                viewModel.CleanUp();
            }
        }
    }

    public enum DialogOption
    {
        Cancel,
        Option1,
        Option2
    }
}
