using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImgUrl { get; set; }
        public string Descireption { get; set; }
        public string About { get; set; }

        public List<Blog> Blogs { get; set; }


    }
}
