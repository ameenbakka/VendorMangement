using Microsoft.EntityFrameworkCore;
using vendor_Management.Context;
using vendor_Management.Dto;
using vendor_Management.Model;

namespace vendor_Management.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _dbContext;

        public ContactService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VendorContactPerson>> GetAllPersonsAsync()
        {
            return await _dbContext.contactPerson.ToListAsync();
        }

        public async Task<VendorContactPerson> AddPersonAsync(ContactCreatingDto contactCreatingDto)
        {
            var entity = new VendorContactPerson
            {
                Name = contactCreatingDto.Name,
                ContactEmail = contactCreatingDto.ContactEmail,
                ContactNo = contactCreatingDto.ContactNo,
                VendorId = contactCreatingDto.VendorId
            };

            await _dbContext.contactPerson.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> DeletePersonAsync(int id)
        {
            var person = await _dbContext.contactPerson.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
                return false;

            _dbContext.contactPerson.Remove(person);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}