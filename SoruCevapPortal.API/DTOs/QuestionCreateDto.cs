namespace SoruCevapPortal.API.DTOs
{
    public class QuestionCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}