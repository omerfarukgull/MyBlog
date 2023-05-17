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
    public class AuthorManager : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository= authorRepository;
        }
        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public Author LoginControl(string email, string password)
        {
            return _authorRepository.LoginControl(email, password);
        }
    }
}
