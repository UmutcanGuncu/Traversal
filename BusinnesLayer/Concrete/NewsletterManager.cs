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
    public class NewsletterManager : INewsletterService
    {
        INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void TAdd(Newsletter entity)
        {
            _newsletterDal.Insert(entity);
        }

        public void TDelete(Newsletter entity)
        {
           _newsletterDal.Delete(entity);
        }

        public Newsletter TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> TGetList()
        {
            return _newsletterDal.GetAll();
        }

        public void TUpdate(Newsletter entity)
        {
           _newsletterDal.Update(entity);
        }
    }
}
