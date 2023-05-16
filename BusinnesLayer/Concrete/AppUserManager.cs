using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TAdd(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void TDelete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetAll();
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}
