using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Core.Services;
using api.Features.Administration.Authentication.Models.Request;
using api.Features.Administration.Authentication.Models.Resposne;
using api.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Authentication
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminAuthenticationController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly JWTokenService _jwtokenService;

        public AdminAuthenticationController(AdminService adminService, JWTokenService jwtokenService)
        {
            _adminService = adminService;
            _jwtokenService = jwtokenService;
        }

        [HttpPost("generate_token")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateTokenAsyn([FromBody] TokenRequest request)
        {
            var validationResult = await _adminService.ValidateCredentials(request.Username, request.Password);
            if (!validationResult.Succeed)
                return BadRequest(validationResult.Error.Message);
            var token = _jwtokenService.CreateToken(new List<Claim>
            {
                new Claim("id", validationResult.Data.Id.ToString()),
                new Claim("username", validationResult.Data.Username),
            });
            return Ok(new TokenResponse { Token = token });
        }

        [HttpGet("renew_token")]
        public async Task<IActionResult> RenewTokenAsync([FromHeader(Name = "Authorization")] string oldToken)
        {
            oldToken = oldToken.Split(' ')[1];
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(oldToken) as JwtSecurityToken;
            var token = _jwtokenService.CreateToken(tokenS.Claims.ToList());
            return Ok(new TokenResponse { Token = token });
        }
    }
}
