namespace SoruCevapPortal.API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}