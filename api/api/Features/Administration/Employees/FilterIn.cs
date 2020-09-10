using System.Linq;
using api.Core.Models;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Employees
{
    public class FilterIn : BaseFilterIn<Employee>
    {
        public string Username { get; set; }
        public bool IsActive { get; set; } = true;

        public override IQueryable<Employee> Apply(IQueryable<Employee> queryable)
        {
            queryable = base.Apply(queryable);
            return queryable.Where(x => (Username == null || EF.Functions.Like(x.Username.ToUpper(), $"%{Username.ToUpper()}%")) && x.IsActive == IsActive);
        }
    }
}
