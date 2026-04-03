using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoruCevapPortal.API.DTOs;
using SoruCevapPortal.API.Models;
using SoruCevapPortal.API.Repositories;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };
            await _categoryRepository.AddAsync(category);
            return Ok(new { message = "Kategori başarıyla eklendi!" });
        }
    }
}