using Microsoft.EntityFrameworkCore;
using vendor_Management.Model;
namespace vendor_Management.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<VendorContactPerson> contactPerson { get; set; }
        public DbSet<VendorGeoService> vendorGeoServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendorContactPerson>()
                .HasOne(v => v.Vendors)
                .WithMany(r => r.VendorList)
                .HasForeignKey(x => x.VendorId);
            modelBuilder.Entity<VendorGeoService>()
               .HasOne(v => v.Vendors)
               .WithMany(r => r.GeoList)
               .HasForeignKey(x => x.VendorId);
        }
    }
}
