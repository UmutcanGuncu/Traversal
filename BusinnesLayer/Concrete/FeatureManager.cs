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
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void TAdd(Feature entity)
        {
            _featureDal.Insert(entity);
        }

        public void TDelete(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public Feature TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetAll();
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
