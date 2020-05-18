using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Authentication
{
    public class GenerateTokenIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
