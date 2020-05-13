using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Core.Services;
using api.Features.Administration.Authentication.Models.Request;
using api.Infrastructure.Security;
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

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var validationResult = await _adminService.ValidateCredentials(request.Username, request.Password);
            if (!validationResult.Succeed)
                return BadRequest(validationResult.Error.Message);
            var token = _jwtokenService.CreateToken(new List<Claim>
            {
                new Claim("username", validationResult.Data.Username),
            });
            return Ok(token);
        }
    }
}
