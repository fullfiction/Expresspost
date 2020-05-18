using api.Core.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Store
{
    public class StoreContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        // public DbSet<Country> Countries { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            modelBuilder.Entity<Admin>(options =>
            {
                options.ToTable("Admins");
                options.Property(prop => prop.Id).IsRequired();
                options.Property(prop => prop.Created).IsRequired();
                options.Property(prop => prop.Username).IsRequired().HasMaxLength(50);
                options.Property(prop => prop.Password).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.IsActive).IsRequired().HasDefaultValue(true);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Username).IsUnique();
            });

            modelBuilder.Entity<Company>(options =>
            {
                options.ToTable("Companies");
                options.Property(prop => prop.Id).IsRequired();
                options.Property(prop => prop.Created).IsRequired();
                options.Property(prop => prop.Name).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.ParentId);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Name).IsUnique();

                options.HasOne(rel => rel.Parent).WithMany(rel => rel.Childs).HasForeignKey(fk => fk.ParentId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Country>(options =>
            {
                options.ToTable("Countries");
                options.Property(prop => prop.Id).IsRequired();
                options.Property(prop => prop.Created).IsRequired();
                options.Property(prop => prop.Name).IsRequired().HasMaxLength(100);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Name).IsUnique();
            });

            modelBuilder.Entity<CompanyCountry>(options =>
            {
                options.ToTable("CompanyCountries");
                options.Property(prop => prop.Id).IsRequired();
                options.Property(prop => prop.Created).IsRequired();

                options.Property(prop => prop.CompanyId).IsRequired();
                options.Property(prop => prop.CountryId).IsRequired();

                options.HasKey(key => key.Id);
                options.HasOne(rel => rel.Company).WithMany(rel => rel.Countries).HasForeignKey(fk => fk.CompanyId).OnDelete(DeleteBehavior.Cascade);
                options.HasOne(rel => rel.Country).WithMany(rel => rel.Companies).HasForeignKey(fk => fk.CountryId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
