using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.ViewModels
{
    public interface IViewModel : ISubscriber, IInitializeAsync
    {
        bool IsBusy { get; set; }
    }

    public interface IViewModel<in T> : IViewModel
    {
        Task InitializeAsync(T param);
    }
}
