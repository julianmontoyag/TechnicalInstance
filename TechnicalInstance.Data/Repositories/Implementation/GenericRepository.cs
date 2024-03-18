using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechnicalInstance.Data.Context;
using TechnicalInstance.Data.Repositories.Contract;

namespace TechnicalInstance.Data.Repositories.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CreateBulkAsync(List<TEntity> entityList)
        {
            await _dbSet.AddRangeAsync(entityList);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public int GetTotalDtoRecords(IQueryable<object> query)
        {
            return query.Count();
        }

        public async Task<IList<object>> GetDtoList(IQueryable<object> query, int pageSize, int currentPage)
        {
            if (pageSize > 0 && currentPage > 0)
            {
                query = query.Skip(pageSize * (currentPage - 1)).Take(pageSize);
            }

            return await query.ToListAsync();

        }
    }
}
