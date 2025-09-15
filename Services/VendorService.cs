using Microsoft.EntityFrameworkCore;
using vendor_Management.Context;
using vendor_Management.Dto;
using vendor_Management.Model;

namespace vendor_Management.Services
{
    public class VendorService : IVendorService
    {
        private readonly AppDbContext _dbContext;

        public VendorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Vendor>> GetAllVendorsAsync()
        {
            return await _dbContext.vendors.ToListAsync();
        }

        public async Task<Vendor?> GetVendorByIdAsync(int id)
        {
            return await _dbContext.vendors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddVendorAsync(VendorCreatingDto vendorCreatingDto)
        {
            var vendor = new Vendor
            {
                PAN = vendorCreatingDto.PAN,
                VendorDescription = vendorCreatingDto.VendorDescription,
                FinanceVendorId = vendorCreatingDto.FinanceVendorId,
                VendorGroup = vendorCreatingDto.VendorGroup,
                VendorGroupId = vendorCreatingDto.VendorGroupId
            };

            await _dbContext.vendors.AddAsync(vendor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteVendorAsync(int id)
        {
            var vendor = await _dbContext.vendors.FirstOrDefaultAsync(x => x.Id == id);

            if (vendor == null)
                return false;

            _dbContext.vendors.Remove(vendor);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVendorAsync(int id, VendorCreatingDto vendorCreatingDto)
        {
            var existingVendor = await _dbContext.vendors.FirstOrDefaultAsync(v => v.Id == id);

            if (existingVendor == null)
                return false;

            existingVendor.PAN = vendorCreatingDto.PAN;
            existingVendor.VendorGroup = vendorCreatingDto.VendorGroup;
            existingVendor.VendorGroupId = vendorCreatingDto.VendorGroupId;
            existingVendor.FinanceVendorId = vendorCreatingDto.FinanceVendorId;
            existingVendor.VendorDescription = vendorCreatingDto.VendorDescription;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
