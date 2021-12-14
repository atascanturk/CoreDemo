using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null);
        Admin Get(Expression<Func<Admin, bool>> filter);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
