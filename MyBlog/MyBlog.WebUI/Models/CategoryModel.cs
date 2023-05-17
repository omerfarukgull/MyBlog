using MyBlog.Entities.Concrete;

namespace MyBlogWebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Url { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
