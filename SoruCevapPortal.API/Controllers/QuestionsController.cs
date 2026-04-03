using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoruCevapPortal.API.DTOs;
using SoruCevapPortal.API.Models;
using SoruCevapPortal.API.Repositories;
using System.Security.Claims;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {
        private readonly IRepository<Question> _questionRepository;


        public QuestionsController(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllAsync();
            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionCreateDto model)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newQuestion = new Question
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = model.CategoryId,
                AppUserId = userId, 
                ViewCount = 0,
                IsResolved = false
            };

            await _questionRepository.AddAsync(newQuestion);

            return Ok(new { message = "Sorunuz başarıyla paylaşıldı!", questionId = newQuestion.Id });
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);

            if (question == null)
                return NotFound(new { message = "Böyle bir soru bulunamadı." });

            return Ok(question);
        }
    }
}