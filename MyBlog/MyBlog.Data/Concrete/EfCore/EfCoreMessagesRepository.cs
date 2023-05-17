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
    public class EfCoreMessagesRepository:EfCoreGenericRepository<Messages,BlogContext>,IMessagesRepository
    {
        public void MessageStatusUpdate(int id)
        {
            using (var context = new BlogContext())
            {
                var cmd = "update Messages set MessageStatus=1 where Id=@p0 ";
                context.Database.ExecuteSqlRaw(cmd, id);
            }
        }
    }
}
