using vendor_Management.Dto;
using vendor_Management.Model;
namespace vendor_Management.Services
{
    public interface IVendorService
    {
        Task<List<Vendor>> GetAllVendorsAsync();
        Task<Vendor?> GetVendorByIdAsync(int id);
        Task<Vendor> AddVendorAsync(VendorCreatingDto dto);
        Task<bool> UpdateVendorAsync(int id, VendorCreatingDto vendorCreatingDto);
        Task<bool> DeleteVendorAsync(int id);
    }
}
