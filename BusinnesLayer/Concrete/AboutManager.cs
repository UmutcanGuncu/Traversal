using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Insert(entity);

        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetAll();
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
