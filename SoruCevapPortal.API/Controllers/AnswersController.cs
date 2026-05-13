using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoruCevapPortal.API.DTOs;
using SoruCevapPortal.API.Models;
using SoruCevapPortal.API.Repositories;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SoruCevapPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswersController : ControllerBase
    {
        private readonly IRepository<Answer> _answerRepository;

        public AnswersController(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] AnswerCreateDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var answer = new Answer
            {
                Content = model.Content,
                QuestionId = model.QuestionId,
                AppUserId = userId,
                IsAccepted = false
            };

            await _answerRepository.AddAsync(answer);
            return Ok(new { message = "Cevabınız başarıyla eklendi!" });
        }

        [HttpGet("question/{questionId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnswersByQuestion(int questionId)
        {
            var answers = await _answerRepository.Table
                .Include(a => a.AppUser)
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();

            return Ok(answers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, [FromBody] AnswerCreateDto model)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var answer = await _answerRepository.GetByIdAsync(id);
            if (answer == null)
                return NotFound(new { message = "Güncellenecek cevap bulunamadı." });


            if (answer.AppUserId != userId)
                return Unauthorized(new { message = "Sadece kendi cevaplarınızı düzenleyebilirsiniz." });


            answer.Content = model.Content;

            _answerRepository.Update(answer);
            return Ok(new { message = "Cevap başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _answerRepository.GetByIdAsync(id);
            if (answer == null) return NotFound(new { message = "Cevap bulunamadı." });

            _answerRepository.Remove(answer);
            return Ok(new { message = "Cevap başarıyla silindi." });
        }

        [HttpGet("user/{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnswersByUser(string userId)
        {
            var userAnswers = await _answerRepository.Table
                .Where(a => a.AppUserId == userId)
                .ToListAsync();

            return Ok(userAnswers);
        }
    }
}