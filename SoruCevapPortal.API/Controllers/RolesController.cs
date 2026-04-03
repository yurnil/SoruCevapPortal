using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
                return Ok(new { message = $"'{roleName}' rolü başarıyla oluşturuldu." });
            }
            return BadRequest(new { message = "Bu rol zaten mevcut." });
        }
    }
}
