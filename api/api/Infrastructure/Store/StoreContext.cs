using api.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Store
{
    public class StoreContext : DbContext
    {
        public DbSet<Employee> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Localization> Localizations { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            modelBuilder.Entity<Employee>(options =>
            {
                options.ToTable("Employees");

                options.Property(prop => prop.Username).IsRequired().HasMaxLength(50);
                options.Property(prop => prop.Password).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.IsActive).IsRequired().HasDefaultValue(true);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Username).IsUnique();
            });

            modelBuilder.Entity<Company>(options =>
            {
                options.ToTable("Companies");

                options.Property(prop => prop.Name).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.ParentId);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Name).IsUnique();

                options.HasOne(rel => rel.Parent).WithMany(rel => rel.Childs).HasForeignKey(fk => fk.ParentId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Country>(options =>
            {
                options.ToTable("Countries");

                options.Property(prop => prop.Name).IsRequired().HasMaxLength(100);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Name).IsUnique();
            });

            modelBuilder.Entity<Branch>(options => 
            {
                options.ToTable("Branches");

                options.Property(prop => prop.AddressLine1).IsRequired().HasMaxLength(300);
                options.Property(prop => prop.AddressLine2).IsRequired().HasMaxLength(300);
                options.Property(prop => prop.Email).IsRequired().HasMaxLength(200);
                options.Property(prop => prop.Phonenumber).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.ZipCode).HasMaxLength(20);
                options.Property(prop => prop.State).HasMaxLength(100);

                options.Property(prop => prop.CompanyId).IsRequired();
                options.Property(prop => prop.CountryId).IsRequired();

                options.HasKey(key => key.Id);
                options.HasOne(rel => rel.Company).WithMany(x=> x.Branches).HasForeignKey(fk => fk.CompanyId);
                options.HasOne(rel => rel.Country).WithMany(x=> x.Branches).HasForeignKey(fk => fk.CountryId);
            });

            modelBuilder.Entity<Localization>(options => 
            {
                options.ToTable("Localizations");

                options.Property(prop => prop.Context).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.Key).IsRequired().HasMaxLength(100);
                options.Property(prop => prop.Value).IsRequired();
                options.Property(prop => prop.Locale).IsRequired().HasMaxLength(10);

                options.HasKey(key => key.Id);
                options.HasIndex(index => index.Key);
                options.HasIndex(index => index.Context);
                options.HasIndex(index => new {index.Key, index.Context, index.Locale}).IsUnique();
            });

            modelBuilder.Entity<BranchEmployee>(options =>
            {
                options.ToTable("BranchEmployee");

                options.Property(prop => prop.BranchId).IsRequired();
                options.Property(prop => prop.EmployeeId).IsRequired();

                options.HasKey(key => key.Id);
                options.HasOne(rel => rel.Branch).WithMany(rel => rel.Employees).HasForeignKey(fk => fk.BranchId).OnDelete(DeleteBehavior.Cascade);
                options.HasOne(rel => rel.Employee).WithMany(rel => rel.Branches).HasForeignKey(fk => fk.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
