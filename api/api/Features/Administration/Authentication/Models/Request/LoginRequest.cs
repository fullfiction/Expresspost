using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Authentication.Models.Request
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
