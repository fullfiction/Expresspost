using System;
using System.Linq;
using api.Core.Store.Entities;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Companies
{
    public class FilterIn : BaseFilterIn<Company>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public override IQueryable<Company> Apply(IQueryable<Company> queryable)
        {
            queryable = base.Apply(queryable);
            return queryable.Where(x => (Name == null || EF.Functions.Like(x.Name.ToUpper(), $"%{Name.ToUpper()}%")) &&
                                        (ParentId == null || (x.ParentId == ParentId && x.Id != ParentId)));
        }
    }
}
