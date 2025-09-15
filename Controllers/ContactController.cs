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

        // Get all contact persons
        [HttpGet("All")]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var persons = await _contactService.GetAllPersonsAsync();

                return Ok(new ApiResponse<IEnumerable<VendorContactPerson>>(
                    persons,
                    persons.Any() ? "Contact persons retrieved successfully" : "No contact persons found",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(null, $"Failed to fetch contact persons: {ex.Message}", false));
            }
        }

        // Create new contact person
        [HttpPost("Create")]
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] ContactCreatingDto contactCreatingDto)
        {
            try
            {
                if (contactCreatingDto == null)
                {
                    return BadRequest(new ApiResponse<string>(
                        null,
                        "Invalid request",
                        false,
                        "VendorContactPerson cannot be null"
                    ));
                }

                var createdPerson = await _contactService.AddPersonAsync(contactCreatingDto);

                return Ok(new ApiResponse<VendorContactPerson>(
                    createdPerson,
                    "Vendor contact person added successfully",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    $"Failed to add vendor contact person: {ex.Message}",
                    false
                ));
            }
        }


        // Delete contact person
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                var deleted = await _contactService.DeletePersonAsync(id);

                if (!deleted)
                {
                    return NotFound(new ApiResponse<string>(
                        null,
                        $"Vendor contact person with id {id} not found",
                        false
                    ));
                }

                return Ok(new ApiResponse<int>(
                    id,
                    $"Vendor contact person with id {id} deleted successfully",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    $"Failed to delete vendor contact person: {ex.Message}",
                    false
                ));
            }
        }
    }
}
