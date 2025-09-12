using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vendor_Management.Model;
using vendor_Management.Services;

namespace vendor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<VendorContactPerson>> GetAllPerson()
        {

            return _contactService.GettAllPersons();

        }
        [HttpPost]
        public IActionResult createPerson(VendorContactPerson vendorContactPerson)
        {
            _contactService.AddPerson(vendorContactPerson);
            return Ok("Vendor added successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult UpdatePerson(int id)
        {
            _contactService.DeletePerson(id);
            return Ok("Vendor Deleted Successfully");
        }
    }
}
