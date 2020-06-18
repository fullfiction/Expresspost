using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Branches
{
    public class UpdateIn
    {
        public bool IsStore { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phonenumber { get; set; }
        public string ZipCode { get; set; }
        [Required]
        public long CountryId { get; set; }
        [Required]
        public long CompanyId { get; set; }
    }
}
