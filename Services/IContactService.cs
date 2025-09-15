using vendor_Management.Dto;
using vendor_Management.Model;

namespace vendor_Management.Services
{
    public interface IContactService
    {
        Task<List<VendorContactPerson>> GetAllPersonsAsync();
        Task<VendorContactPerson> AddPersonAsync(ContactCreatingDto contactCreatingDto);
        Task<bool> DeletePersonAsync(int id);
    }
}
