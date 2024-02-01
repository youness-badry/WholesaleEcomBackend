using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace WholesaleEcomBackend.Data
{
    public class StoreContext : IdentityDbContext<User>
    {
        private const string appUser = "SampleApplication";
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StoreContext(DbContextOptions<StoreContext> options,
            IHttpContextAccessor httpContextAccessor = null) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubSubCategory> SubSubCategories { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }


        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Characteristics)
                .WithMany(e => e.Products)
                .UsingEntity<ProductCharacteristic>();

            modelBuilder.Entity<Product>()
                .HasOne(e => e.SubSubCategory)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.SubSubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public void AddAuditInfo()
        {
            var entities = ChangeTracker.Entries<IEntity>().Where(e => 
                e.State == EntityState.Added || e.State == EntityState.Modified);

            var utcNow = DateTime.UtcNow;
            var user = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? appUser;
            var ipAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedOnUtc = utcNow;
                    entity.Entity.CreatedBy = user;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.LastModifiedOnUtc = utcNow;
                    entity.Entity.LastModifiedBy = user;
                }

                entity.Entity.IPAddress = ipAddress;
            }
        }
    }
}
