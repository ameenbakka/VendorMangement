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

        // Get all vendors
        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            try
            {
                var vendors = await _vendorService.GetAllVendorsAsync();

                return Ok(new ApiResponse<IEnumerable<Vendor>>(
                    vendors,
                    vendors.Any() ? "Vendors retrieved successfully" : "No vendors found",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    "Failed to fetch vendors",
                    false,
                    ex.Message
                ));
            }
        }

        // Get vendor by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorById(int id)
        {
            try
            {
                var vendor = await _vendorService.GetVendorByIdAsync(id);

                if (vendor == null)
                {
                    return NotFound(new ApiResponse<string>(
                        null,
                        $"Vendor with ID {id} not found",
                        false
                    ));
                }

                return Ok(new ApiResponse<Vendor>(
                    vendor,
                    "Vendor retrieved successfully",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    "Failed to fetch vendor",
                    false,
                    ex.Message
                ));
            }
        }

        // Create vendor
        [HttpPost("Create")]
        public async Task<IActionResult> CreateVendor([FromBody] VendorCreatingDto vendor)
        {
            try
            {
                if (vendor == null)
                {
                    return BadRequest(new ApiResponse<string>(
                        null,
                        "Invalid vendor data",
                        false,
                        "Vendor object cannot be null"
                    ));
                }

                await _vendorService.AddVendorAsync(vendor);

                return Ok(new ApiResponse<Vendor>(
                    vendor,
                    "Vendor created successfully",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    "Failed to create vendor",
                    false,
                    ex.Message
                ));
            }
        }

        // Update vendor
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody] Vendor vendor)
        {
            try
            {
                var updated = await _vendorService.UpdateVendorAsync(id, vendor);

                if (!updated)
                {
                    return NotFound(new ApiResponse<string>(
                        null,
                        $"Vendor with ID {id} not found",
                        false
                    ));
                }

                return Ok(new ApiResponse<Vendor>(
                    vendor,
                    "Vendor updated successfully",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    "Failed to update vendor",
                    false,
                    ex.Message
                ));
            }
        }

        // Delete vendor
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            try
            {
                var deleted = await _vendorService.DeleteVendorAsync(id);

                if (!deleted)
                {
                    return NotFound(new ApiResponse<string>(
                        null,
                        $"Vendor with ID {id} not found",
                        false
                    ));
                }

                return Ok(new ApiResponse<string>(
                    null,
                    "Vendor deleted successfully",
                    true
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    null,
                    "Failed to delete vendor",
                    false,
                    ex.Message
                ));
            }
        }
    }
}
