using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EfCore
{
    public class EfCoreAuthorRepository:EfCoreGenericRepository<Author,BlogContext>,IAuthorRepository
    {
        public Author LoginControl(string email,string password)
        {
            using (var context = new BlogContext())
            {
               return  context.Authors.FirstOrDefault(a=>a.Email == email && a.Password == password);
            }
        }
    }
}
