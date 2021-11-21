using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message2 message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message2 message)
        {
            _messageDal.Delete(message);
        }

        public Message2 Get(Expression<Func<Message2, bool>> filter)
        {
           return _messageDal.Get(filter);
        }

        public List<Message2> GetAll(Expression<Func<Message2, bool>> filter = null)
        {
            return _messageDal.GetAll(filter,x=>x.Receiver,x=>x.Sender);
        }

        public void Update(Message2 message)
        {
            _messageDal.Update(message);
        }
    }
}
