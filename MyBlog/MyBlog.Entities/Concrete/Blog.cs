using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? ImgUrl { get; set; }
        public string? Puan { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsApproved { get; set; }

        public DateTime CreateDate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
