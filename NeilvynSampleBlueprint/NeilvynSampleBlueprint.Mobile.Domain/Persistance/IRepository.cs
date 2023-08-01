using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Domain.Persistance
{
    public interface IRepository<TEntity> where TEntity: class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task InsertAsync(IEnumerable<TEntity> entities);
        public void RemoveAll();
    }
}
