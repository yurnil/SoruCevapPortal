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
    }
}