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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        public Notification Get(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.Get(filter);
        }

        public List<Notification> GetAll(Expression<Func<Notification, bool>> filter = null)
        {
            return _notificationDal.GetAll(filter);
        }

        public void Update(Notification notification)
        {
            _notificationDal.Update(notification);
        }
    }
}
