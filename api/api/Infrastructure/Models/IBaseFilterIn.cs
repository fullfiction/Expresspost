using System.Linq;

namespace api.Infrastructure.Models
{
    public interface IBaseFilterIn<TEntity>
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> queryable);
    }
}
