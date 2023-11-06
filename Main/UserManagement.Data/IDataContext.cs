using System.Linq;
using System.Threading.Tasks;


namespace UserManagement.Data;

public interface IDataContext
{

    /// <summary>
    /// Get a list of items
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>


    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
    TEntity? GetEntity<TEntity>(params object?[]? keys) where TEntity : class;

    /// <summary>
    /// Create a new item
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// 
    void Create<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Update an existing item matching the ID
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    void Update<TEntity>(TEntity entity) where TEntity : class;
    Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;


    void Delete<TEntity>(TEntity entity) where TEntity : class;
    Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class;
}
