using System.ComponentModel.DataAnnotations;

namespace vendor_Management.Model
{
    public class VendorGeoService
    {
        public int Id { get; set; }
        [Required]
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? BuildingNo { get; set; }
        public string? StreetName    { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public int VendorId { get; set; }

        public virtual Vendor? Vendors { get; set; }
    }
}
