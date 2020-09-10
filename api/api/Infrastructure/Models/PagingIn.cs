using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Models
{
    public class PagingIn
    {
        [FromQuery(Name = "_start")]
        public int Start { get; set; } = 0;
        [FromQuery(Name = "_end")]
        public int End { get; set; } = 20;
    }
}
