using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericUnitofWorkDal <P> where P : class
    {
        void Insert(P p);
        void MultiUpdate(List<P> p);
        void Update(P p);
        P GetById(int id);
     
    }
}
