using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs
{
    public class AlertDialogModel: ViewModel<AlertDialogParam>
    {
        private string _closeText;
        private string _title;
        private string _message;
        private AlertDialogParam _confirmParam;
        private readonly IAppDialogService _appDialogService;

        public Command CloseCommand { get; } 

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public string CloseText
        {
            get => _closeText;
            set => SetProperty(ref _closeText, value);
        }

        public AlertDialogModel(IAppDialogService appDialogService)
        {
            _appDialogService = appDialogService;

            CloseCommand = new Command(Close);
        }

        public override Task InitializeAsync(AlertDialogParam param)
        {
            _confirmParam = param;
            Message = param.Message;
            Title = param.Title;
            CloseText = param.CloseText;

            return Task.CompletedTask;
        }

        private void Close()
        {
            _confirmParam.OnClose();

            _appDialogService.ClosePopupPage();
        }
    }
}
