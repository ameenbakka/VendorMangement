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
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllVendors()
        {
            var vendors = await _vendorService.GetAllVendorsAsync();
            if (vendors == null || !vendors.Any())
            {
                return NotFound("No vendors found");
            }
            return Ok(vendors);
        }


        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetVendorById(int id)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(id);
            if (vendor == null)
            {
                return NotFound($"Vendor with ID {id} not found");
            }
            return Ok(vendor);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVendor([FromBody] VendorCreatingDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid vendor data.");
            }

            var created = await _vendorService.AddVendorAsync(dto);
            if (created == null)
            {
                return BadRequest("Failed to create vendor.");
            }

            return Ok("Vendor created successfully");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody] VendorCreatingDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid vendor data.");
            }

            bool updated = await _vendorService.UpdateVendorAsync(id, dto);
            if (!updated)
            {
                return NotFound($"Vendor with ID {id} not found");
            }

            return Ok("Vendor updated successfully");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            bool deleted = await _vendorService.DeleteVendorAsync(id);
            if (!deleted)
            {
                return NotFound($"Vendor with ID {id} not found");
            }
            return Ok("Vendor deleted successfully");
        }
    }
}
