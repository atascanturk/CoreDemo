using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotificationService
    {
        List<Notification> GetAll(Expression<Func<Notification, bool>> filter = null);
        Notification Get(Expression<Func<Notification, bool>> filter);
        void Add(Notification notification);
        void Update(Notification notification);
        void Delete(Notification notification);
    }
}
