using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        Category GetByIdWithBlog(int categoryId);
        void DeleteFromCategory(int blogId, int categoryId);
        List<Category> GetAll();
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
