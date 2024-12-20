using EcommerceApi.Data;
using EcommerceApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceApi.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationDbContext _dbContext)
        {
            this._dbcontext = _dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            _dbcontext.SaveChanges();
        }

        public void AddRange(IEnumerable<T> values)
        {
            dbSet.AddRange(values);
            _dbcontext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _dbcontext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> values)
        {
            dbSet.RemoveRange(values);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            if(expression != null)
            {
                query = query.Where(expression);
            }
            foreach(var item in includeProperties)
            {
                query = query.Include(item);
            }
            return query.ToList();
        }

        public T GetOne(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(expression, includeProperties).FirstOrDefault();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            _dbcontext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> values)
        {
            dbSet.UpdateRange(values);
            _dbcontext.SaveChanges();
        }
    }
}
