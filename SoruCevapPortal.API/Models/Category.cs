namespace SoruCevapPortal.API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; } 
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}