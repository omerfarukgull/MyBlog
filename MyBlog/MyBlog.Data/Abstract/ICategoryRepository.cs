using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetByIdWithBlog(int categoryId);
        void DeleteFromCategory(int blogId, int categoryId);
    }
}
