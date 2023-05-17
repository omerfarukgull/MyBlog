using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Abstract
{
    public interface IMessagesRepository : IRepository<Messages>
    {
        void MessageStatusUpdate(int id);
    }
}
