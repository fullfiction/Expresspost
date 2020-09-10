using System.Threading.Tasks;
using api.Core.Services;
using api.Core.Models;

namespace api.Infrastructure.Store.Seed
{
    public class Seed
    {
        private StoreContext context;

        public Seed(StoreContext context)
        {
            this.context = context;
        }

        public async Task SeedAdminAsync(EmployeeService employeeService)
        {
            var administrator = await employeeService.GetByUsernameAsync("ADMINISTRATOR");
            if (administrator == null)
            {
                administrator = new Employee
                {
                    IsActive = true,
                    Username = "ADMINISTRATOR",
                    Password = "123asdASD"
                };
                await employeeService.CreateAsync(administrator);
            }
            else
            {
                administrator.IsActive = true;
                await employeeService.UpdateAsync(administrator.Id, administrator);
            }
        }
    }
}
