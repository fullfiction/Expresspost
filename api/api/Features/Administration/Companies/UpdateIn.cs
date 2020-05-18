using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Companies
{
    public class UpdateIn
    {
        [Required]
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
