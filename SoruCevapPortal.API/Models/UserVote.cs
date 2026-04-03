namespace SoruCevapPortal.API.Models
{
    public class UserVote : BaseEntity
    {
        public bool IsUpvote { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int? QuestionId { get; set; }
        public Question Question { get; set; }

        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}