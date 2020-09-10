using System.ComponentModel.DataAnnotations;

namespace api.Features.Administration.Localizations
{
    public class UpdateIn
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Context { get; set; }
        [Required]
        public string Locale { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
