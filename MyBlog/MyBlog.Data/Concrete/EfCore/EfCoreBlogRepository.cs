using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EfCore
{
    public class EfCoreBlogRepository : EfCoreGenericRepository<Blog, BlogContext>, IBlogRepository
    {
        public Blog GetBlogDetails(string url)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs
                                .Where(i => i.Url == url)
                                .Include(i => i.BlogCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();

            }
        }
        public Blog GetByIdWithCategories(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs
                                .Where(i => i.Id == id)
                                .Include(i => i.BlogCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();
            }
        }

        public List<Blog> GetBlogByCategory(string name)
        {
            //using (var context = new BlogContext())
            //{
            //    var blogs = context.Blogs.AsQueryable();

            //    if (!string.IsNullOrEmpty(name))
            //    {
            //        blogs = blogs
            //                        .Include(i => i.BlogCategories)
            //                        .ThenInclude(i => i.Category)
            //                        .Where(i => i.BlogCategories.Any(a => a.Category.Url == name));
            //    }

            //    return blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //}
            using (var context = new BlogContext())
            {
                var blogs = context.Blogs.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    blogs = blogs
                                    .Include(i => i.BlogCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.BlogCategories.Any(a => a.Category.Url == name));
                }

                return blogs.Where(i => i.IsApproved == true).ToList();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new BlogContext())
            {
                var blogs = context.Blogs.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    blogs = blogs
                                    .Include(i => i.BlogCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.BlogCategories.Any(a => a.Category.Url == category));
                }

                return blogs.Count();
            }
        }
        public void BlogAdd(Blog entity, int[] categoryIds)
        {

            using (var context = new BlogContext())
            {
                var model = new Blog()
                {
                    Title = entity.Title,
                    Url = entity.Url,
                    Description = entity.Description,
                    Content = entity.Content,
                    ImgUrl = entity.ImgUrl,
                    Puan = entity.Puan,
                    CreateDate = entity.CreateDate,
                    AuthorId = entity.AuthorId,
                    IsApproved= entity.IsApproved,

                    BlogCategories = categoryIds.Select(catid => new BlogCategory()
                    {
                        BlogId = entity.Id,
                        CategoryId = catid
                    }).ToList(),
                };
                context.Blogs.Add(model);
                context.SaveChanges();

            };
        }
        public void BloggUpdate(Blog entity, int[] categoryIds)
        {

            using (var context = new BlogContext())
            {
                var blog = context.Blogs
                                   .Include(i => i.BlogCategories)
                                   .FirstOrDefault(i => i.Id == entity.Id);


                if (blog != null)
                {
                    blog.Title = entity.Title;
                    blog.Url = entity.Url;
                    blog.Description = entity.Description;
                    blog.Content = entity.Content;
                    blog.ImgUrl = entity.ImgUrl;
                    blog.Puan = entity.Puan;
                    blog.CreateDate = entity.CreateDate;
                    blog.AuthorId = entity.AuthorId;
                    blog.IsApproved = entity.IsApproved;
                    blog.BlogCategories = categoryIds.Select(catid => new BlogCategory()
                    {
                        BlogId = entity.Id,
                        CategoryId = catid
                    }).ToList();

                    context.Blogs.Update(blog);
                    context.SaveChanges();
                }

            };
        }

        public List<Blog> GetByIsApprovedTrue()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Where(i=>i.IsApproved==true).ToList();
            }
        }
        public List<Blog> GetByIsApprovedFalse()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Where(i => i.IsApproved == false).ToList();
            }
        }

    }
}

