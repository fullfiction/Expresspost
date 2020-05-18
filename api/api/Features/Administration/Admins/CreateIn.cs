using System;
using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Admins
{
    public class CreateIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
