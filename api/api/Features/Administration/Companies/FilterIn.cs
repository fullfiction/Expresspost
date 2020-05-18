using System;
using System.Linq;
using api.Core.Store.Entities;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Companies
{
    public class FilterIn : IBaseFilterIn<Company>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public IQueryable<Company> Apply(IQueryable<Company> queryable)
        {
            return queryable.Where(x => (Name == null || EF.Functions.Like(x.Name.ToUpper(), $"%{Name.ToUpper()}%")) &&
                                        (ParentId == null || (x.ParentId == ParentId && x.Id != ParentId)));
        }
    }
}
