using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Countries
{
    public class CreateIn
    {
        [Required]
        public string Name { get; set; }
    }
}
