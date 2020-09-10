using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Employees
{
    public class UpdateIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
