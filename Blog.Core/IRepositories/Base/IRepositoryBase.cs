using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Core.IRepositories.Base
{
    /// <summary>
    /// 仓储基类接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        #region 查询

        /// <summary>
        /// 根据条件查询数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        /// <summary>
        /// （异步版本）根据条件查询数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 根据主键查询单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindEntityById(TKey id);
        /// <summary>
        /// （异步版本）根据主键查询单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindEntityByIdAsync(TKey id);

        /// <summary>
        /// 根据条件查询一条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// （异步版本）根据条件查询一条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查询一个集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> FindAllList(Expression<Func<TEntity, bool>> predicate = null);
        /// <summary>
        /// （异步版本）查询一个集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> FindAllListAsync(Expression<Func<TEntity, bool>> predicate = null);

        IQueryable<TEntity> LoadQueryable(Expression<Func<TEntity, bool>> predicate = null);
        Task<IQueryable<TEntity>> LoadQueryableAsync(Expression<Func<TEntity, bool>> predicate = null);

        #endregion

        #region 添加

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(TEntity entity);
        /// <summary>
        /// （异步版本）插入一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> InsertAsync(TEntity entity);

        /// <summary>
        /// 插入一个集合
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int InsertCollection(IEnumerable<TEntity> entities);
        /// <summary>
        /// （异步版本）插入一个集合
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> InsertCollectionAsync(IEnumerable<TEntity> entities);

        #endregion

        #region 更新

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// 更新一个集合
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int UpdateCollection(IEnumerable<TEntity> entities);
        Task<int> UpdateCollectionAsync(IEnumerable<TEntity> entities);

        #endregion

        #region 删除

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// 删除一个集合
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int DeleteCollection(IEnumerable<TEntity> entities);
        Task<int> DeleteCollectionAsync(IEnumerable<TEntity> entities);

        #endregion

        #region 执行sql语句

        /// <summary>
        /// 添加、更新、删除
        /// </summary>
        /// <param name="executeSql">sql语句</param>
        /// <param name="parameters">SqlParameter参数数组</param>
        /// <returns></returns>
        int ExecuteSqlCommand(string executeSql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string executeSql, params object[] parameters);

        /// <summary>
        /// 执行查询sql语句 注意:始终对原始 SQL 查询使用参数化!
        /// </summary>
        /// <param name="querySql">sql语句</param>
        /// <param name="parameters">SqlParameter参数数组</param>
        /// <returns></returns>
        IQueryable<TEntity> FromSqlRaw(string querySql, params object[] parameters);
        Task<IQueryable<TEntity>> FromSqlRawAsync(string querySql, params object[] parameters);

        /// <summary>
        /// 执行带有内插字符串的sql查询语句
        /// 使用示例:_repository.FromSqlRaw( $"SELECT * FROM Table WHERE Id= {id} ")
        /// </summary>
        /// <param name="formattableString"></param>
        /// <returns></returns>
        IQueryable<TEntity> FromSqlInterpolated(FormattableString formattableString);
        Task<IQueryable<TEntity>> FromSqlInterpolatedAsync(FormattableString formattableString);

        #endregion
    }
}