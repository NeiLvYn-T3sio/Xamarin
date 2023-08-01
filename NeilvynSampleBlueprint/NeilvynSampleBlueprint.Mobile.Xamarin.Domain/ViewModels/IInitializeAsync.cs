using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.ViewModels
{
    public interface IInitializeAsync
    {
        Task InitializeAsync(object param);
        void CleanUp();
    }
}
