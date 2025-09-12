using Microsoft.EntityFrameworkCore;
using vendor_Management.Context;
using vendor_Management.Model;

namespace vendor_Management.Services
{
    public class VendorService : IVendorService
    {
        public readonly AppDbContext _dbContext;
        public VendorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Vendor> GettAllVendors()
        {
            return _dbContext.vendors.ToList();
        }
        public List<Vendor> GetVendorById(int id)
        {
            return _dbContext.vendors.Where(x => x.Id == id).ToList();

        }
        public void AddVendors(Vendor vendor)
        {
            _dbContext.vendors.Add(vendor);
            _dbContext.SaveChanges();
        }
        public void DeleteVendors(int id)
        {
            var vender = _dbContext.vendors.FirstOrDefault(x => x.Id == id);
            _dbContext.vendors.Remove(vender);
            _dbContext.SaveChanges();
        }
        public void UpdateVedors(int id, Vendor vendor)
        {
            var existingVender= _dbContext.vendors.FirstOrDefault(vender => vender.Id == id);
            existingVender.PAN= vendor.PAN;
            existingVender.VendorGroup= vendor.VendorGroup;
            existingVender.VendorGroupId= vendor.VendorGroupId;
            existingVender.FinanceVendorId= vendor.FinanceVendorId;
            existingVender.VendorDescription= vendor.VendorDescription;
            _dbContext.SaveChanges();
        }


    }
}
