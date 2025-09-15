using System.ComponentModel.DataAnnotations;

namespace vendor_Management.Dto
{
    public class ContactCreatingDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public int VendorId { get; set; }
    }
}
