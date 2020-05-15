using System.Collections.Generic;
using System.Threading.Tasks;
using api.Core.Services;
using api.Core.Store;
using api.Core.Store.Entities;
using api.Infrastructure.Controllers;
using api.Infrastructure.Extensions;
using api.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Admins
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class AdminsController : BaseController<Admin>
    {
        private readonly AdminService _adminService;

        public AdminsController(UnitOfWork _uow, AdminService adminService) : base(_uow)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResultModel<List<Admin>>), 200)]
        public async Task<IActionResult> GetAsync()
        {
            var querable = _store.GetByExpression(x => true);
            var count = await querable.CountAsync();
            var data = await querable.ToListAsync();
            return data.AsApiResult<Admin>(count);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultModel<Admin>), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var admin = await _store.GetByIdAsync(id);
            return admin.AsApiResult();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultModel<Admin>), 200)]
        public async Task<IActionResult> UpdateAsync(long id, Admin admin)
        {
            var updateResult = await _adminService.UpdateAsync(id, admin);
            return updateResult.AsApiResult();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultModel<Admin>), 200)]
        public async Task<IActionResult> CreateAsync(Admin admin)
        {
            var updateResult = await _adminService.CreateAsync(admin);
            return updateResult.AsApiResult();
        }
    }
}
