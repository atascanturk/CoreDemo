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

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message Get(Expression<Func<Message, bool>> filter)
        {
           return _messageDal.Get(filter);
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetAll(filter);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
