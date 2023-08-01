using NeilvynSampleBlueprint.Mobile.Domain.Persistance;
using NeilvynSampleBlueprint.Mobile.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MobileDbContext _mobileDbContext;

        public IRepository<User> Users { get; }

        public UnitOfWork(MobileDbContext mobileDbContext)
        {
            _mobileDbContext = mobileDbContext;
            this.Users = new Repository<User>(mobileDbContext);
        }

        public async Task<int> Complete()
        {
            try
            {
                return await _mobileDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return 0;
            }
        }
    }
}
