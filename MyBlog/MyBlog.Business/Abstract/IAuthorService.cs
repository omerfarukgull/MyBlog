using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface IAuthorService
    {
        Author GetById(int id);
        List<Author> GetAll();
        Author LoginControl(string email, string password);
    }
}
