using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Domain.Repositories
{
    /// <summary>
    /// 此接口由所有仓储实现，以确保固定方法的实现。
    /// </summary>
    /// <typeparam name="TEntity">泛型实体</typeparam>
    /// <typeparam name="TPrimaryKey">实体的主键</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        #region Select/Get/Query

        /// <summary>
        /// 用于获取用于从整个表中检索实体的<see cref="IQueryable"/>。
        /// </summary>
        /// <returns>可用于从数据库中选择实体</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 用于获取用于从整个表中检索实体的<see cref="IQueryable"/>。
        /// 一个或多个
        /// </summary>
        /// <param name="propertySelectors">包含表达式的列表。</param>
        /// <returns>可用于从数据库中选择实体</returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        /// <summary>
        /// 用于获取所有实体。
        /// </summary>
        /// <returns>所有实体列表</returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 用于获取所有实体。
        /// </summary>
        /// <returns>所有实体列表</returns>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>
        /// 用于根据给定的<paramref name="predicate"/>获取所有实体。
        /// </summary>
        /// <param name="predicate">筛选实体的条件</param>
        /// <returns>所有实体列表</returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 用于根据给定的<paramref name="predicate"/>获取所有实体。
        /// </summary>
        /// <param name="predicate">筛选实体的条件</param>
        /// <returns>所有实体列表</returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 用于在整个实体上运行查询。
        /// </summary>
        /// <param name="queryMethod">此方法用于查询实体</param>
        /// <returns>查询结果</returns>
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        /// <summary>
        /// 获取具有给定主键的实体。
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>Entity</returns>
        TEntity Get(TPrimaryKey id);

        /// <summary>
        /// 获取具有给定主键的实体。
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// 使用给定谓词仅获取一个实体。
        /// 如果没有实体或多个实体，则引发异常。
        /// </summary>
        /// <param name="predicate">Entity</param>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 使用给定谓词仅获取一个实体。
        /// 如果没有实体或多个实体，则引发异常。
        /// </summary>
        /// <param name="predicate">Entity</param>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取具有给定主键的实体，如果没有找到，则获取null。
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>Entity or null</returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// 获取具有给定主键的实体，如果没有找到，则获取null。
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>Entity or null</returns>
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        /// <summary>
        /// 获取具有给定给定谓词的实体，如果没有找到，则获取null。
        /// </summary>
        /// <param name="predicate">谓词过滤实体</param>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取具有给定给定谓词的实体，如果没有找到，则获取null。
        /// </summary>
        /// <param name="predicate">谓词过滤实体</param>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 创建具有给定主键的实体，但不访问数据库。
        /// </summary>
        /// <param name="id">要加载的实体的主键</param>
        /// <returns>Entity</returns>
        TEntity Load(TPrimaryKey id);

        #endregion

        #region Insert

        /// <summary>
        /// 插入新实体。
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 插入新实体。
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 插入新实体并获取其Id。
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Id of the entity</returns>
        TPrimaryKey InsertAndGetId(TEntity entity);

        /// <summary>
        /// 插入新实体并获取其Id。
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Id of the entity</returns>
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        /// <summary>
        /// 根据Id的值插入或更新给定的实体。
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity InsertOrUpdate(TEntity entity);

        /// <summary>
        /// 根据Id的值插入或更新给定的实体。
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        /// <summary>
        /// 根据Id的值插入或更新给定的实体。
        /// 还返回实体的Id。
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Id of the entity</returns>
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        /// <summary>
        /// 根据Id的值插入或更新给定的实体。
        /// 还返回实体的Id。
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Id of the entity</returns>
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        #endregion

        #region Update

        /// <summary>
        /// 更新现有实体。
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 更新现有实体。
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 更新现有实体。
        /// </summary>
        /// <param name="id">实体Id</param>
        /// <param name="updateAction">可用于更改实体值的操作</param>
        /// <returns>更新的实体</returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        /// <summary>
        /// 更新现有实体。
        /// </summary>
        /// <param name="id">实体Id</param>
        /// <param name="updateAction">可用于更改实体值的操作</param>
        /// <returns>更新的实体</returns>
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

        #endregion

        #region Delete

        /// <summary>
        /// 删除一个实体。
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 删除一个实体。
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// 通过主键删除实体。
        /// </summary>
        /// <param name="id">实体的主键</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// 通过主键删除实体。
        /// </summary>
        /// <param name="id">实体的主键</param>
        Task DeleteAsync(TPrimaryKey id);

        /// <summary>
        /// 按功能删除许多实体。
        /// 注意:所有符合给定谓词的实体都将被检索和删除。
        /// 如果有太多的实体，这可能会导致严重的性能问题
        /// 给定谓词。
        /// </summary>
        /// <param name="predicate">筛选实体的条件</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 按功能删除许多实体。
        /// 注意:所有符合给定谓词的实体都将被检索和删除。
        /// 如果有太多的实体，这可能会导致严重的性能问题
        /// 给定谓词。
        /// </summary>
        /// <param name="predicate">筛选实体的条件</param>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Aggregates

        /// <summary>
        /// 获取此存储库中所有实体的计数。
        /// </summary>
        /// <returns>Count of entities</returns>
        int Count();

        /// <summary>
        /// 获取此存储库中所有实体的计数。
        /// </summary>
        /// <returns>Count of entities</returns>s
        Task<int> CountAsync();

        /// <summary>
        /// 根据给定的<paramref name="predicate"/>获取存储库中所有实体的计数。
        /// </summary>
        /// <param name="predicate">一种过滤计数的方法</param>
        /// <returns>Count of entities</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据给定的<paramref name="predicate"/>获取存储库中所有实体的计数。
        /// </summary>
        /// <param name="predicate">一种过滤计数的方法</param>
        /// <returns>Count of entities</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取此存储库中所有实体的计数(如果预期的返回值是greather而不是<see cref="int.MaxValue"/>，则使用此方法)。
        /// </summary>
        /// <returns>Count of entities</returns>
        long LongCount();

        /// <summary>
        /// 获取此存储库中所有实体的计数(如果预期的返回值是greather而不是<see cref="int.MaxValue"/>，则使用此方法)。
        /// </summary>
        /// <returns>Count of entities</returns>
        Task<long> LongCountAsync();

        /// <summary>
        /// 根据给定的<paramref name="predicate"/>获取存储库中所有实体的计数
        /// (如果期望的返回值大于<see cref="int.MaxValue"/>，则使用此重载).
        /// </summary>
        /// <param name="predicate">A method to filter count</param>
        /// <returns>Count of entities</returns>
        long LongCount(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据给定的<paramref name="predicate"/>获取存储库中所有实体的计数
        /// (如果期望的返回值大于<see cref="int.MaxValue"/>，则使用此重载).
        /// </summary>
        /// <param name="predicate">A method to filter count</param>
        /// <returns>Count of entities</returns>
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}