using MyBlog.Entities.Concrete;

namespace MyBlogWebUI.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? ImgUrl { get; set; }
        public string? Puan { get; set; }
        public bool Isapproved { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Category> selectedCategories { get; set; }
        public int AuthorId { get; set; }

    }
}
