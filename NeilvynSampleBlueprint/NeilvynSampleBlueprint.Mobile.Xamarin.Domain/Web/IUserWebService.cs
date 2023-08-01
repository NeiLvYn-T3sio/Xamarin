using NeilvynSampleBlueprint.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web
{
    public interface IUserWebService
    {
        Task<IEnumerable<UserDTO>> GetUsers();
    }
}