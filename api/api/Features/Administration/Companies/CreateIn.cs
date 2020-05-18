using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Companies
{
    public class CreateIn
    {
        [Required]
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
