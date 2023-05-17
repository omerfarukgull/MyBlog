using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface IBlogService
    {
        Blog GetById(int id);
        List<Blog> GetBlogByCategory(string name);
        Blog GetBlogDetails(string url);
        List<Blog> GetAll();
        void Add(Blog entity);
        void Update(Blog entity);
        void Delete(Blog entity);
        int GetCountByCategory(string category);
        void BlogAdd(Blog entity, int[] categoryIds);
        Blog GetByIdWithCategories(int id);
        void BloggUpdate(Blog entity, int[] categoryIds);

        List<Blog> GetByIsApprovedTrue();
        List<Blog> GetByIsApprovedFalse();
    }
}
