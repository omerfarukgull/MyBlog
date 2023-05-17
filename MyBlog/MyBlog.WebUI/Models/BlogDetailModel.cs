using MyBlog.Entities.Concrete;

namespace MyBlog.WebUI.Models
{
    public class BlogDetailModel
    {
        public Blog? Blog { get; set; }
        public List<Category>? Categories { get; set; }
        public Comment Comment { get; set; }    
    }
}
