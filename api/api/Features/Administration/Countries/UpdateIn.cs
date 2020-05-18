using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Countries
{
    public class UpdateIn
    {
        [Required]
        public string Name { get; set; }
    }
}
