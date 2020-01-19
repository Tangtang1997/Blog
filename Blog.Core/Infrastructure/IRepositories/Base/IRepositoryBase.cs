using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure.IRepositories.Base
{
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(TKey id);

        Task<List<TEntity>> FindAllListAsync();

        Task<int> InsertAsync(TEntity entity);
    }
}