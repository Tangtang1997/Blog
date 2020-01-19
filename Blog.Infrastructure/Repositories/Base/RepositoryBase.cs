using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.IRepositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories.Base
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        protected async Task<int> SaveChanges() => await DbContext.SaveChangesAsync();

        public async Task<TEntity> FindByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> FindAllListAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);

            return await SaveChanges();
        }
    }
}