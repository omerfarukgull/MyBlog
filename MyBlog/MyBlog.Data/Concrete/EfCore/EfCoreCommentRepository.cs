using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EfCore
{
    public class EfCoreCommentRepository:EfCoreGenericRepository<Comment,BlogContext>, ICommentRepository
    {
    }
}
