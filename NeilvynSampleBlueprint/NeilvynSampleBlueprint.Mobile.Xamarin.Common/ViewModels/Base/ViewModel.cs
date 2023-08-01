using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.ViewModels;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base
{
    public class ViewModel : NotifyPropertyChanged, IViewModel
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public virtual void CleanUp()
        {
        }

        public virtual void Subscribe()
        {
        }

        public virtual void Unsubscribe()
        {
        }

        public virtual Task InitializeAsync(object param)
        {
            return Task.CompletedTask;
        }
    }

    public abstract class ViewModel<T> : ViewModel, IViewModel<T>
    {
        protected T FamilyInfo { get; set; }

        public abstract Task InitializeAsync(T param);

        public override async Task InitializeAsync(object param)
        {
            if (param is T paramT)
            {
                await InitializeAsync(paramT);

                FamilyInfo = paramT;
            }
        }
    }
}
