using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<P> where P : class
    {
        void Insert(P p);
        void Delete(P p);
        void Update(P p);
        List<P> GetAll();
        P GetById(int id);
        List<P> GetListByFilter(Expression<Func<P, bool>> filter);
    }
}
