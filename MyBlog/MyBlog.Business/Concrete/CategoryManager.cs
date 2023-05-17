using MyBlog.Business.Abstract;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }
        public void Add(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int blogId, int categoryId)
        {
            _categoryRepository.DeleteFromCategory(blogId, categoryId);
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdWithBlog(int categoryId)
        {
            return _categoryRepository.GetByIdWithBlog(categoryId);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
