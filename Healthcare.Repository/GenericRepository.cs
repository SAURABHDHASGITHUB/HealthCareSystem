
using System.Linq.Expressions;
using Healthcare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Healthcare.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HealthcareDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(HealthcareDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public  void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();

        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {                
            return await _dbSet
                .AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public  void Update(T entity)
        {
            _dbSet.Update(entity);

        }
    }
}
