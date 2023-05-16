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
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public List<Destination> GetLast4Destinations()
        {
            return _destinationDal.GetLast4Destinations();
        }

        public void TAdd(Destination entity)
        {
            _destinationDal.Insert(entity);
        }

        public void TDelete(Destination entity)
        {
            _destinationDal.Delete(entity);
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public Destination TGetDestinationsWithGuide(int id)
        {
            return _destinationDal.GetDestinationsWithGuide(id); 
        }

        public List<Destination> TGetList()
        {
           return _destinationDal.GetAll();
        }

        public void TUpdate(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}
