using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace api.Infrastructure.Security
{
    public class JWTokenService
    {
        private readonly SecurtiyOptions options;

        public JWTokenService(IOptionsSnapshot<SecurtiyOptions> options)
        {
            this.options = options.Value;
        }

        public string CreateToken(List<Claim> claims)
        {
            if (claims == null)
                throw new ArgumentNullException(nameof(claims));
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(options.TokenExpiersMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
