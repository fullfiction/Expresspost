using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Core.Store.Entities;
using api.Infrastructure.Store;

namespace api.Core.Store
{
    public class Store<T> where T : Entity
    {
        protected readonly StoreContext _context;

        public Store(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.FindAsync<T>(id);
        }

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T Create(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}
