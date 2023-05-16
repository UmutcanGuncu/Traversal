    using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<P> : IGenericDal<P> where P : class
    {
        public void Delete(P p)
        {
            var context = new Context();
            context.Remove(p);
            context.SaveChanges();
        }

        public List<P> GetAll()
        {
            var context = new Context();
            return context.Set<P>().ToList();
        }

        public void Insert(P p)
        {
            var context = new Context();
            context.Add(p);
            context.SaveChanges();
        }
        public P GetById(int id) 
        {
            var context = new Context();
            return context.Set<P>().Find(id);
        }
        public void Update(P p)
        {
            var context = new Context();
            context.Update(p);
            context.SaveChanges();
        }

        public List<P> GetListByFilter(Expression<Func<P, bool>> filter)
        {
            var context= new Context();
            return context.Set<P>().Where(filter).ToList();
        }
    }
}
