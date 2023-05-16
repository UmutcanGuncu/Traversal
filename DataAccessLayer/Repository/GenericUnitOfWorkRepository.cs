using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUnitOfWorkRepository<P> : IGenericUnitofWorkDal<P> where P : class
    {
        private readonly Context _context;

        public GenericUnitOfWorkRepository(Context context)
        {
            _context = context;
        }

        public P GetById(int id)
        {
            return _context.Set<P>().Find(id);
        }

        public void Insert(P p)
        {
            _context.Add(p);
        }

        public void MultiUpdate(List<P> p)
        {
            _context.UpdateRange(p);
        }

        public void Update(P p)
        {
            _context.Update(p);
        }
    }
}
