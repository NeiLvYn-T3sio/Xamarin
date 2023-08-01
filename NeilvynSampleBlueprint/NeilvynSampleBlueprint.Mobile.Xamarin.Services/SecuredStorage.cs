using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services
{
    [ExcludeFromCodeCoverage]
    public class SecuredStorage : ISecuredStorage
    {
        public void ClearAllKeys()
        {
            SecureStorage.RemoveAll();
        }

        public void RemoveKey(string key)
        {
            SecureStorage.Remove(key);
        }

        public async Task<string> RetrieveKey(string key)
        {
            return await SecureStorage.GetAsync(key);
        }

        public async Task SetKey(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }
    }
}
