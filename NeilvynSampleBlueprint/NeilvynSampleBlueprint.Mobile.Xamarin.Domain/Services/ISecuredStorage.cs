using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services
{
    public interface ISecuredStorage
    {
        Task SetKey(string key, string value);

        Task<string> RetrieveKey(string key);

        void ClearAllKeys();

        void RemoveKey(string key);
    }
}