using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Core.Store;
using api.Core.Store.Entities;
using api.Infrastructure.Security;
using api.Infrastructure.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Features
{
    /// <summary>
    /// Test controller
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TestController : ControllerBase
    {
        Store<Admin> _store;
        JWTokenService _tokenService;
        private readonly ILogger<TestController> _logger;

        public TestController(Store<Admin> store, JWTokenService tokenService, ILogger<TestController> logger)
        {
            _logger = logger;
            _tokenService = tokenService;
            _store = store;
        }

        [HttpGet("demo")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Demo()
        {
            var admin = await _store.GetByExpression(x => x.Username == "Administrator").FirstOrDefaultAsync();
            var token = _tokenService.CreateToken(new List<Claim>
            {
                new Claim("sub", admin.Id.ToString()),
                new Claim("username", admin.Username)
            });
            _logger.LogInformation(token.ToString());
            _logger.LogDebug(token.ToString());
            _logger.LogError(token.ToString());
            _logger.LogTrace(token.ToString());
            _logger.LogCritical(token.ToString());
            return Ok(token);
        }

        [HttpGet("Demo2/{id}")]
        [MapToApiVersion("2")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<DateTime>> Demo2(DateTime dateTime)
        {
            return dateTime;
        }
    }
}
