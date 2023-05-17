using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Abstract
{
    public interface IBlogRepository:IRepository<Blog>
    {
        Blog GetBlogDetails(string url);
        List<Blog> GetBlogByCategory(string name);
        int GetCountByCategory(string category);
        void BlogAdd(Blog entity, int[] categoryIds);
        Blog GetByIdWithCategories(int id);
        void BloggUpdate(Blog entity, int[] categoryIds);
        List<Blog> GetByIsApprovedTrue();
        List<Blog> GetByIsApprovedFalse();
    }
}
