using System;
using System.Threading.Tasks;
using api.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Demo(long id)
        {
            _logger.LogInformation(id.ToString());
            _logger.LogDebug(id.ToString());
            _logger.LogError(id.ToString());
            _logger.LogTrace(id.ToString());
            _logger.LogCritical(id.ToString());
            return Ok(id);
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
