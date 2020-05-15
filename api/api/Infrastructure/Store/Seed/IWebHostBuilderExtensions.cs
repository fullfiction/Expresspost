using System;
using System.Threading.Tasks;
using api.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace api.Infrastructure.Store.Seed
{
    public static class IWebHostBuilderExtensions
    {
        public static async Task<IHost> SeedAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetService<StoreContext>();
                var adminService = scope.ServiceProvider.GetService<AdminService>();

                await new Seed(context).SeedAdminAsync(adminService);
            }
            return host;
        }
    }
}
