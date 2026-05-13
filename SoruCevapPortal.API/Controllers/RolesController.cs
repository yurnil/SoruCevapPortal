using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoruCevapPortal.API.Models;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

      
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole(string userEmail, string roleName)
        {
            
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                return NotFound(new { message = "Böyle bir kullanıcı bulunamadı." });

            
            if (!await _roleManager.RoleExistsAsync(roleName))
                return NotFound(new { message = "Böyle bir rol bulunamadı. Önce rolü oluşturun." });

            
            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok(new { message = $"{user.FirstName} adlı kullanıcıya '{roleName}' rolü başarıyla atandı!" });
            }

            return BadRequest(result.Errors);
        }
    }
}