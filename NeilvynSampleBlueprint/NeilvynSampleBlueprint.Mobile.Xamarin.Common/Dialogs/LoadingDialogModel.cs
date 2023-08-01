using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs
{
    public class LoadingDialogModel : ViewModel<LoadingDialogParam>
    {
        private string _message;

        public override Task InitializeAsync(LoadingDialogParam param)
        {
            Message = param.Message;

            return Task.CompletedTask;
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
    }
}
