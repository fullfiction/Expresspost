using System.Threading.Tasks;
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

        public async Task SeedAdminAsync()
        {
            var administrator = await context.Admins.FirstOrDefaultAsync(admin => admin.Username == "ADMINISTRATOR");
            if (administrator == null)
            {
                administrator = new Admin
                {
                    IsActive = true,
                    Username = "ADMINISTRATOR",
                    Password = "123asdASD"
                };
                context.Add(administrator);
            }
            else
            {
                administrator.IsActive = true;
                context.Update(administrator);
            }
            await context.SaveChangesAsync();
        }
    }
}
