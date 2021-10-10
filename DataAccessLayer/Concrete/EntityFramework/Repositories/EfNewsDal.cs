using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Repositories
{
    public class EfNewsDal : EfEntityRepositoryBase<News,Context>, INewsDal
    {
    }
}
