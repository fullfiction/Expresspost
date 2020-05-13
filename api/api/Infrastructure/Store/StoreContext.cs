using api.Core.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Store
{
    public class StoreContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            modelBuilder.Entity<Admin>(options =>
            {
                options.ToTable("Admins");
                options.Property(prop => prop.Id).IsRequired();
                options.Property(prop => prop.Username).IsRequired().HasMaxLength(50);
                options.Property(prop => prop.Password).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.IsActive).IsRequired().HasDefaultValue(true);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Username).IsUnique();
            });
        }
    }
}
