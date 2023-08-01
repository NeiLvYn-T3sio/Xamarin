using NeilvynSampleBlueprint.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsersFromDb();
    }
}