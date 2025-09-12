using System.Numerics;
using vendor_Management.Context;
using vendor_Management.Model;

namespace vendor_Management.Services
{
    public class ContactService : IContactService
    {
        public readonly AppDbContext _dbContext;
        public ContactService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<VendorContactPerson> GettAllPersons()
        {
            return _dbContext.contactPerson.ToList();
        }
        public void AddPerson(VendorContactPerson vendorContactPerson)
        {
            _dbContext.contactPerson.Add(vendorContactPerson);
            _dbContext.SaveChanges();
        }
        public void DeletePerson(int id)
        {
            var vender = _dbContext.vendors.FirstOrDefault(x => x.Id == id);
            _dbContext.vendors.Remove(vender);
            _dbContext.SaveChanges();
        }
    }
}
