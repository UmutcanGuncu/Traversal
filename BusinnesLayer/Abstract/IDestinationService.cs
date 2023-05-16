using EntityLayer.Entityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public Destination TGetDestinationsWithGuide(int id);
        public List<Destination> GetLast4Destinations();
    }
}
