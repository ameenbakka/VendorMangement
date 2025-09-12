using vendor_Management.Model;

namespace vendor_Management.Services
{
    public interface IContactService
    {
        public List<VendorContactPerson> GettAllPersons();
        public void AddPerson(VendorContactPerson vendorContactPerson);
        public void DeletePerson(int id);

    }
}
