using System.Threading.Tasks;
using api.Core.Services;
using api.Core.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Store.Seed
{
    public class Seed
    {
        private StoreContext context;

        public Seed(StoreContext context)
        {
            this.context = context;
        }

        public async Task SeedAdminAsync(AdminService adminService)
        {
            var administrator = await adminService.GetByUsernameAsync("ADMINISTRATOR");
            if (administrator == null)
            {
                administrator = new Admin
                {
                    IsActive = true,
                    Username = "ADMINISTRATOR",
                    Password = "123asdASD"
                };
                await adminService.CreateAsync(administrator);
            }
            else
            {
                administrator.IsActive = true;
                await adminService.UpdateAsync(administrator.Id, administrator);
            }
        }
    }
}
