using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vendor_Management.Dto;
using vendor_Management.Model;
using vendor_Management.Services;

namespace vendor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

   
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _contactService.GetAllPersonsAsync();
            if (persons == null || !persons.Any())
            {
                return NotFound("No contact persons found");
            }
            return Ok(persons);
        }

    
        [HttpPost("create")]
        public async Task<IActionResult> CreatePerson([FromBody] ContactCreatingDto contactCreatingDto)
        {
            if (contactCreatingDto == null)
            {
                return BadRequest("Invalid contact person data.");
            }

            var createdPerson = await _contactService.AddPersonAsync(contactCreatingDto);
            if (createdPerson == null)
            {
                return BadRequest("Failed to create contact person.");
            }

            return Ok("Contact person created successfully");
        }

      
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            bool deleted = await _contactService.DeletePersonAsync(id);
            if (!deleted)
            {
                return NotFound($"Contact person with ID {id} not found");
            }

            return Ok("Contact person deleted successfully");
        }
    }
}
