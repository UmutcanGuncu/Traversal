using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class SubaboutManager : ISubaboutService
    {
        ISubaboutDal _subaboutDal;

        public SubaboutManager(ISubaboutDal subaboutDal)
        {
            _subaboutDal = subaboutDal;
        }

        public void TAdd(SubAbout entity)
        {
            _subaboutDal.Insert(entity);
        }

        public void TDelete(SubAbout entity)
        {
            _subaboutDal.Delete(entity);
        }

        public SubAbout TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> TGetList()
        {
            return _subaboutDal.GetAll();
        }

        public void TUpdate(SubAbout entity)
        {
            _subaboutDal.Update(entity);
        }
    }
}
