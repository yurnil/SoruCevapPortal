namespace SoruCevapPortal.API.Models
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public bool IsResolved { get; set; } = false;

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<UserVote> Votes { get; set; }
    }
}