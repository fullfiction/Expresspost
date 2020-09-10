using System;
using System.Linq;
using api.Core.Models;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Countries
{
    public class FilterIn : BaseFilterIn<Country>
    {
        public string Name { get; set; }

        public override IQueryable<Country> Apply(IQueryable<Country> queryable)
        {
            queryable = base.Apply(queryable);
            return queryable.Where(x => (Name == null || EF.Functions.Like(x.Name.ToUpper(), $"%{Name.ToUpper()}%")));
        }
    }
}
