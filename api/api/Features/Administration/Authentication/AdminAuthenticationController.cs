using System;
using Microsoft.AspNetCore.Mvc;

namespace api.Features.Administration.Authentication
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminAuthenticationController : ControllerBase
    {

    }
}
