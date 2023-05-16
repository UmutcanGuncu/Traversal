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
    public class About2Manager : IAbout2Service
    {
        IAbout2Dal _about2Dal;

        public About2Manager(IAbout2Dal about2Dal)
        {
            _about2Dal = about2Dal;
        }

        public void TAdd(About2 entity)
        {
            _about2Dal.Insert(entity);
        }

        public void TDelete(About2 entity)
        {
            _about2Dal.Delete(entity);
        }

        public About2 TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About2> TGetList()
        {
            return _about2Dal.GetAll();
        }

        public void TUpdate(About2 entity)
        {
            _about2Dal.Update(entity);
        }
    }
}
