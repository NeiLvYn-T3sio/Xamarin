using NeilvynSampleBlueprint.Mobile.Models;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Domain.Persistance
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        Task<int> Complete();
    }
}
