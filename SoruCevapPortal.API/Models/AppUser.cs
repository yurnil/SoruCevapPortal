using Microsoft.AspNetCore.Identity;

namespace SoruCevapPortal.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<UserVote> Votes { get; set; }
    }
}