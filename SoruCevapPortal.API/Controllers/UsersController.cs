using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using SoruCevapPortal.API.DTOs;
using SoruCevapPortal.API.Models;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public UsersController(UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }


        [HttpPut("updateProfile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UserUpdateDto model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound(new { message = "Kullanıcı bulunamadı." });

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "userImages");
                if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);
                string filePath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                user.ProfileImageUrl = "/userImages/" + fileName;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { message = "Profil başarıyla güncellendi!", photoUrl = user.ProfileImageUrl });
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("getProfile/{id}")]
        public async Task<IActionResult> GetProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.ProfileImageUrl
            });
        }


        [HttpGet]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.Select(u => new
            {
                id = u.Id,
                fullName = u.FirstName + " " + u.LastName,
                email = u.Email,
                userName = u.UserName
            }).ToListAsync();

            return Ok(users);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound(new { message = "Kullanıcı bulunamadı." });

            await _userManager.DeleteAsync(user);
            return Ok(new { message = "Kullanıcı başarıyla silindi." });
        }
    }
}