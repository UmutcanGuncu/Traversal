using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Entityies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationsWithGuide(int id)
        {
            using (var context= new Context())
            {
                return context.Destinations.Where(x=>x.Id == id).Include(x=>x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            using(var context = new Context())
            {
                var values =context.Destinations.Take(4).OrderByDescending(x=>x.Id).ToList();
                return values;
            }
        }
    }
}
