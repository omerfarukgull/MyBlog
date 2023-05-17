using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface IMessagesService
    {
        Messages GetById(int id);
        void MessageStatusUpdate(int id);
        List<Messages> GetAll();
        void Add(Messages entity);
        void Update(Messages entity);
        void Delete(Messages entity);
    }
}
