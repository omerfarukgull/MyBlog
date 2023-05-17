using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }


        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
}
