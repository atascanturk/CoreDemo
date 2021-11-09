using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll(Expression<Func<Message, bool>> filter = null);
        Message Get(Expression<Func<Message, bool>> filter);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
