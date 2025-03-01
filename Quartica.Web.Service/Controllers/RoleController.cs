using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;
using Quartica.Web.Service.Repository;

namespace Quartica.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetRolesAsync")]
        public async Task<IActionResult> GetRolesAsync()
        {
            try
            {
                var roles = await _roleService.GetRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetRoleByIdAsync/{roleId}")]
        public async Task<IActionResult> GetRolesAsync(long roleId)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(roleId);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("InsertOrUpdateRoleAsync")]
        public async Task<IActionResult> InsertOrUpdateRoleAsync(Role role)
        {
            try
            {
                var dbrole = await _roleService.InsertOrUpdateRoleAsync(role);
                return Ok(dbrole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
