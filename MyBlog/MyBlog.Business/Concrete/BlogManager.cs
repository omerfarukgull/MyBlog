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
    public class BlogManager : IBlogService
    {
        private IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
                _blogRepository = blogRepository;
        }
        public void Add(Blog entity)
        {
            _blogRepository.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogRepository.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public Blog GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        public Blog GetBlogDetails(string url)
        {
            return _blogRepository.GetBlogDetails(url);
        }

        public List<Blog> GetBlogByCategory(string name)
        {
            return _blogRepository.GetBlogByCategory(name);
        }

        public void Update(Blog entity)
        {
            _blogRepository.Update(entity);
        }

        public int GetCountByCategory(string category)
        {
            return _blogRepository.GetCountByCategory(category);
        }

        public void BlogAdd(Blog entity, int[] categoryIds)
        {
            _blogRepository.BlogAdd(entity, categoryIds);
        }

        public Blog GetByIdWithCategories(int id)
        {
            return _blogRepository.GetByIdWithCategories(id);
        }

        public void BloggUpdate(Blog entity, int[] categoryIds)
        {
          _blogRepository.BloggUpdate(entity, categoryIds);
        }

        public List<Blog> GetByIsApprovedTrue()
        {
           return _blogRepository.GetByIsApprovedTrue();
        }

        public List<Blog> GetByIsApprovedFalse()
        {
            return _blogRepository.GetByIsApprovedFalse();
        }
    }
}
