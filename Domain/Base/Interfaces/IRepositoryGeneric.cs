using System.Linq.Expressions;


namespace Domain.Base.Interfaces
{
    public interface IRepositoryGeneric<T> where T : EntityBase
    {
        Task<T?> Find(object id);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);

        Task<IEnumerable<T>> GetAll();

        Task<T?> FindFirstOrDefault(
            Expression<Func<T, bool>> predicate,
            string includeProperties = ""
        );

        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
        );
    }
}
