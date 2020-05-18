using System;
using System.Linq;
using api.Core.Store.Entities;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Admins
{
    public class FilterIn : IBaseFilterIn<Admin>
    {
        public string Username { get; set; }
        public bool IsActive { get; set; } = true;

        public IQueryable<Admin> Apply(IQueryable<Admin> queryable)
        {
            return queryable.Where(x => (Username == null || EF.Functions.Like(x.Username.ToUpper(), $"%{Username.ToUpper()}%")) && x.IsActive == IsActive);
        }
    }
}
