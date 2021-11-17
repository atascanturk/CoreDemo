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
        List<Message2> GetAll(Expression<Func<Message2, bool>> filter = null);
        Message2 Get(Expression<Func<Message2, bool>> filter);
        void Add(Message2 message);
        void Update(Message2 message);
        void Delete(Message2 message);
    }
}
