using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Core.Models;
using api.Infrastructure.Store;
using Microsoft.EntityFrameworkCore;

namespace api.Core.Store
{
    public class Store<T> where T : Entity
    {
        protected readonly StoreContext _context;

        public Store(StoreContext context)
        {
            _context = context;
        }

        public StoreContext Context { get { return _context; } }

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> expression, bool track = false)
        {
            var querable = _context.Set<T>().Where(expression);
            return track ? querable : querable.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(long id, bool track = false)
        {
            return await GetByExpression(x => x.Id == id, track).FirstOrDefaultAsync();
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
