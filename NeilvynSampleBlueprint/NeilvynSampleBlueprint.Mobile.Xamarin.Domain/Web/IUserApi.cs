using NeilvynSampleBlueprint.Mobile.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web
{
    public interface IUserApi
    {
        [Get("/users")]
        Task<IEnumerable<UserDTO>> GetUsers();
    }
}
