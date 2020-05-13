using System;

namespace api.Infrastructure.Security
{
    public class SecurtiyOptions
    {
        public string JwtKey { get; set; }
        public int TokenExpiersMinutes { get; set; }
    }
}
