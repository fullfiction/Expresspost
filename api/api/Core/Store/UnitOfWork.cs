using System.Threading.Tasks;
using api.Core.Extensions;
using api.Core.Models;
using api.Core.Store.Entities;
using api.Infrastructure.Store;

namespace api.Core.Store
{
    public class UnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public Store<Admin> AdminStore => new Store<Admin>(_context);

        public Result<int> Save()
        {
            return _context.SaveChanges().ToResult<int>();
        }

        public async Task<Result<int>> SaveAsync()
        {
            return (await _context.SaveChangesAsync()).ToResult<int>();
        }
    }
}
