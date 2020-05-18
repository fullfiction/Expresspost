using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Models
{
    public class PagingIn
    {
        [FromQuery(Name = "_start")]
        [Required]
        public int Start { get; set; }
        [FromQuery(Name = "_end")]
        [Required]
        public int End { get; set; }
    }
}
