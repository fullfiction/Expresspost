using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Core.Services;
using api.Infrastructure.Extensions;
using api.Infrastructure.Models;
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
        private readonly EmployeeService _employeeService;
        private readonly JWTokenService _jwtokenService;

        public AdminAuthenticationController(EmployeeService employeeService, JWTokenService jwtokenService)
        {
            _employeeService = employeeService;
            _jwtokenService = jwtokenService;
        }

        [HttpPost("generate_token")]
        [ProducesResponseType(typeof(ResultModel<string>), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateTokenAsync([FromBody] GenerateTokenIn request)
        {
            var validationResult = await _employeeService.ValidateCredentials(request.Username, request.Password);
            if (!validationResult.Succeed)
                return validationResult.AsApiResult();
            var token = _jwtokenService.CreateToken(new List<Claim>
            {
                new Claim("id", validationResult.Data.Id.ToString()),
                new Claim("username", validationResult.Data.Username),
            });
            return token.AsApiResult();
        }

        [HttpGet("renew_token")]
        [ProducesResponseType(typeof(ResultModel<string>), 200)]
        public async Task<IActionResult> RenewTokenAsync([FromHeader(Name = "Authorization")] string oldToken)
        {
            var sub = HttpContext.User.GetSub();
            var admin = await _employeeService.GetActiveBySubAsync(sub);
            if (admin == null)
                return Unauthorized();
            var token = _jwtokenService.CreateToken(new List<Claim>
            {
                new Claim("id", admin.Id.ToString()),
                new Claim("username", admin.Username),
            });
            return token.AsApiResult();
        }
    }
}
