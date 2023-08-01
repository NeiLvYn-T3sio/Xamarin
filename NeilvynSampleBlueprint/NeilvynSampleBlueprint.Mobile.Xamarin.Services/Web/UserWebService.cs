using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using Refit;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web
{
    public class UserWebService : IUserWebService
    {
        private readonly IUserApi _userApi;
        private readonly IConnectivity _connectivity;
        private readonly ISecuredStorage _securedStorage;
        private string _accessToken;

        public UserWebService(IUserApi userApi,IConnectivity connectivity,ISecuredStorage securedStorage)
        {
            _userApi = userApi;
            _connectivity = connectivity;
            _securedStorage = securedStorage;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            try
            {
                if (!_connectivity.IsInternetConnected)
                {
                    throw new NoInternetConnectivityException();
                }

                _accessToken = await _securedStorage.RetrieveKey(SharedKeys.ApplicationToken);

                var result = await _userApi.GetUsers();

                return result;
            }
            catch (ApiException apiException)
            {
                if (apiException.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new ServerErrorException();
                }

                throw;
            }
        }
    }
}
