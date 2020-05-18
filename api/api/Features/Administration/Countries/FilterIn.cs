using System;
using System.Linq;
using api.Core.Store.Entities;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Countries
{
    public class FilterIn : IBaseFilterIn<Country>
    {
        public string Name { get; set; }

        public IQueryable<Country> Apply(IQueryable<Country> queryable)
        {
            return queryable.Where(x => (Name == null || EF.Functions.Like(x.Name.ToUpper(), $"%{Name.ToUpper()}%")));
        }
    }
}
