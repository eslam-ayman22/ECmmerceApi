using System.Linq.Expressions;

namespace EcommerceApi.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> values);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> values);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> values);

        IEnumerable<T> Get(Expression<Func<T, bool>> expression,
            params Expression<Func<T, object>>[] includeProperties);

        T GetOne(Expression<Func<T, bool>> expression,
            params Expression<Func<T, object>>[] includeProperties);

    }
}
