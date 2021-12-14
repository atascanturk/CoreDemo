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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.Get(filter);
        }

        public List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.GetAll(filter);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
