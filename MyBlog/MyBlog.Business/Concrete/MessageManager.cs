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
    public class MessageManager : IMessagesService
    {

        private IMessagesRepository _messagesRepository;

        public MessageManager(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }
        public void Add(Messages entity)
        {
            _messagesRepository.Add(entity);
        }

        public void Delete(Messages entity)
        {
            throw new NotImplementedException();
        }

        public List<Messages> GetAll()
        {
            return _messagesRepository.GetAll();
        }

        public Messages GetById(int id)
        {
          return  _messagesRepository.GetById(id);
        }

        public void MessageStatusUpdate(int id)
        {
            _messagesRepository.MessageStatusUpdate(id);
        }

        public void Update(Messages entity)
        {
            _messagesRepository.Update(entity);
        }
    }
}
