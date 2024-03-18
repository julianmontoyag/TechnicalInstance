using System.Linq.Expressions;

namespace TechnicalInstance.Data.Repositories.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<int> CreateBulkAsync(List<TEntity> entityList);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IList<object>> GetDtoList(IQueryable<object> query, int pageSize, int currentPage);
        int GetTotalDtoRecords(IQueryable<object> query);
    }
}
