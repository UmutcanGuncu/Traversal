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
    public class Feature2Manager : IFeature2Service
    {
        IFeature2Dal _feature2Dal;

        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }

        public void TAdd(Feature2 entity)
        {
            _feature2Dal.Update(entity);
        }

        public void TDelete(Feature2 entity)
        {
            _feature2Dal.Delete(entity);
        }

        public Feature2 TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature2> TGetList()
        {
           return _feature2Dal.GetAll();
        }

        public void TUpdate(Feature2 entity)
        {
            _feature2Dal.Update(entity);
        }
    }
}
