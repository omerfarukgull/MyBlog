using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Url { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }
    }
}
