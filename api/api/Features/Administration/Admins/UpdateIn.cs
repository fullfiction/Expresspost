using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Admins
{
    public class UpdateIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
