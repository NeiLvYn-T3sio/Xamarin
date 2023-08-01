using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs
{
    public class ConfirmDialogModel : ViewModel<ConfirmDialogParam>
    {
        private ConfirmDialogParam _confirmParam;
        
        public ConfirmDialogModel()
        {
            CancelCommand = new Command(Cancel);
            ConfirmCommand = new Command(Confirm);
        }
        
        public override Task InitializeAsync(ConfirmDialogParam param)
        {
            _confirmParam = param;
            Message = param.Message;
            Title = param.Title;
            PositiveText = param.PositiveText;
            NegativeText = param.NegativeText;
            
            return Task.CompletedTask;
        }

        public Command CancelCommand { get; } 
        public Command ConfirmCommand { get; }
        
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _negativeText;

        public string NegativeText
        {
            get => _negativeText;
            set => SetProperty(ref _negativeText, value);
        }

        private string _positiveText;

        public string PositiveText
        {
            get => _positiveText;
            set => SetProperty(ref _positiveText, value);
        }
        
        private void Confirm()
        {
            _confirmParam.OnConfirm(true);
        }

        private void Cancel()
        {
            _confirmParam.OnConfirm(false);
        }
    }
}