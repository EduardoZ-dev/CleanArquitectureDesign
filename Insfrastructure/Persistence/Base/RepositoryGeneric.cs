using Domain.Base;
using Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Base
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : EntityBase
    {
        protected readonly DbContext _db;
        protected readonly DbSet<T> _dbset;

        public RepositoryGeneric(DbContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
            _dbset = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public IQueryable<T> FindBy(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public async Task<T?> Find(object id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<T?> FindFirstOrDefault(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
            Commit();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            Commit();
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
            Commit();
        }

        public void AddRange(List<T> entities)
        {
            _dbset.AddRange(entities);
            Commit();
        }

        public void DeleteRange(List<T> entities)
        {
            _dbset.RemoveRange(entities);
            Commit();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}