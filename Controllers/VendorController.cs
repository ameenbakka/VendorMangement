using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vendor_Management.Model;
using vendor_Management.Services;

namespace vendor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        public readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService) {
            _vendorService = vendorService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> GetAllVendor()
        {

            return _vendorService.GettAllVendors();

        }
        [HttpGet("{id}")]
        public ActionResult<Vendor> GetVendorById(int id)
        {
            var vendor= _vendorService.GetVendorById(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }
        [HttpPost]
        public IActionResult CreateVendor(Vendor vendor)
        {
            _vendorService.AddVendors(vendor);
            return Ok("Vendor added successfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVendor(int id,Vendor vendor)
        {
            _vendorService.UpdateVedors(id, vendor);
            return Ok("Vendor Data updated");
        }
        [HttpDelete("{id}")]
        public IActionResult UpdateVendor(int id)
        {
            _vendorService.DeleteVendors(id);
            return Ok("Vendor Deleted Successfully");
        }

    }
}
