using System;
using System.Linq;
using api.Core.Store.Entities;

namespace api.Infrastructure.Models
{
    public class BaseFilterIn<TEntity> : IBaseFilterIn<TEntity> where TEntity : Entity
    {
        public long? Id { get; set; }

        public virtual IQueryable<TEntity> Apply(IQueryable<TEntity> queryable)
        {
            return queryable.Where(x => (Id == null || x.Id == Id));
        }
    }
}
