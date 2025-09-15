using System.ComponentModel.DataAnnotations;

namespace vendor_Management.Dto
{
    public class VendorCreatingDto
    {
        public int Id { get; set; }
        [Required]
        public string PAN { get; set; }
        [Required]
        public string VendorDescription { get; set; }
        public int FinanceVendorId { get; set; }
        public string VendorGroup { get; set; }
        public int VendorGroupId { get; set; }
    }
}
