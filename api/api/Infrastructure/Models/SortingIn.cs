using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using System;

namespace api.Infrastructure.Models
{
    public class SortingIn<TEntity>
    {
        [FromQuery(Name = "_sort")]
        public string Property { get; set; } = "Created";
        [FromQuery(Name = "_order")]
        public string Order { get; set; } = "DESC";

        public IQueryable<TEntity> Apply(IQueryable<TEntity> queryable)
        {
            return queryable.OrderBy(Property, Order);
        }
    }
}
