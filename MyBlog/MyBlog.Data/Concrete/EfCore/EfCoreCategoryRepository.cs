using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository:EfCoreGenericRepository<Category,BlogContext>,ICategoryRepository
    {
        public Category GetByIdWithBlog(int categoryId)
        {
            using(var context = new BlogContext())
            {
                return context.Categories
                        .Where(i => i.Id == categoryId)
                        .Include(i=>i.BlogCategories)
                        .ThenInclude(i => i.Blog)
                        .FirstOrDefault();
            }
        }

        public void DeleteFromCategory(int blogId, int categoryId)
        {
            using (var context = new BlogContext())
            {
                var cmd = "delete from BlogCategory where BlogId=@p0 and CategoryId=@p1 ";
                context.Database.ExecuteSqlRaw(cmd,blogId,categoryId);
            }
            
        }
    }
}
