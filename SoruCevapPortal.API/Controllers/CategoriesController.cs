using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoruCevapPortal.API.DTOs;
using SoruCevapPortal.API.Models;
using SoruCevapPortal.API.Repositories;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto model)
        {
            if (string.IsNullOrWhiteSpace(model.Name)) return BadRequest("Kategori adı boş olamaz.");

            var newCategory = new Category { Name = model.Name };
            await _categoryRepository.AddAsync(newCategory);
            return Ok(new { message = "Kategori başarıyla eklendi!" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();

            _categoryRepository.Remove(category);
            return Ok(new { message = "Kategori silindi!" });
        }
    }
}