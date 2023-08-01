using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Validations;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private bool _isPasswordMasked = true;
        private bool _hasInvalidEntry;
        private readonly INavigationService _navigationService;
        private readonly IAppDialogService _appDialogService;
        private readonly ILogger<LoginViewModel> _logger;

        public StringValidatableObject EmailValidatableObject { get; }

        public StringValidatableObject PasswordValidatableObject { get; }

        public bool IsPasswordMasked
        {
            get => _isPasswordMasked;
            set => SetProperty(ref _isPasswordMasked, value);
        }

        public bool HasInvalidEntry
        {
            get => _hasInvalidEntry;
            set => SetProperty(ref _hasInvalidEntry, value);
        }

        public ICommand TogglePasswordMaskingCommand { get; }

        public AsyncCommand LoginCommand { get; }

        public LoginViewModel(
            INavigationService navigationService,
            IAppDialogService appDialogService,
            ILogger<LoginViewModel> logger)
        {
            _navigationService = navigationService;
            _appDialogService = appDialogService;
            _logger = logger;

            EmailValidatableObject = new StringValidatableObject()
            {
                IsRequired = true
            };

            EmailValidatableObject.AddValidation(new EmailValidation());

            PasswordValidatableObject = new StringValidatableObject()
            {
                IsRequired = true,
            };

            LoginCommand = new AsyncCommand(OnLogin, CanLoginExecute);

            TogglePasswordMaskingCommand = new Command(OnTogglePasswordMasking);

            EmailValidatableObject.ValueChanged += (s, e) => LoginCommand.ChangeCanExecute();

            PasswordValidatableObject.ValueChanged += (s, e) => LoginCommand.ChangeCanExecute();            
        }

        private void OnTogglePasswordMasking()
        {
            IsPasswordMasked = !IsPasswordMasked;
        }

        private async Task OnLogin()
        {
            try
            {
                ValidateEntries();

                if (!HasInvalidEntry)
                {
                    _logger.LogInformation("You logged in with email {email}", EmailValidatableObject.Value);

                    await _appDialogService.ShowWarning("Valid Credentials");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception in LoginViewModel: {@ex}", ex);

                await _appDialogService.ShowWarning(ex.Message);
            }
            finally
            {
                await _appDialogService.HideLoading();
            }
        }

        private void ValidateEntries()
        {
            var isValid = EmailValidatableObject.Validate() && PasswordValidatableObject.Validate();

            HasInvalidEntry = !isValid;
        }

        private bool CanLoginExecute()
        {
            return EmailValidatableObject.HasValue && PasswordValidatableObject.HasValue;
        }
    }
}
