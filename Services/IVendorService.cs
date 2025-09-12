using vendor_Management.Model;
namespace vendor_Management.Services
{
    public interface IVendorService
    {
        public List<Vendor>  GettAllVendors();
        public List<Vendor> GetVendorById(int id);
        public void AddVendors(Vendor vendor);
        public void UpdateVedors(int id, Vendor vendor);
        public void DeleteVendors(int id);
    }
}
