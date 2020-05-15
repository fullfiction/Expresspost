using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Authentication.Models.Request
{
    public class TokenRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
