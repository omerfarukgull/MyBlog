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
    public class CommetManager : ICommentService
    {
        private  ICommentRepository _commentRepository;
        public CommetManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void Add(Comment entity)
        {
            _commentRepository.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _commentRepository.Delete(entity);
        }

        public List<Comment> GetAll()
        {
           return _commentRepository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public void Update(Comment entity)
        {
            _commentRepository.Update(entity);
        }
    }
}
