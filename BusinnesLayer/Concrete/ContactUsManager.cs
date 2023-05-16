using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Entityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public List<ContactUs> GetListByFilter(int id)
        {
            return _contactUsDal.GetListByFilter(x=>x.Id==id);
        }

        public void TAdd(ContactUs entity)
        {
            _contactUsDal.Insert(entity);
        }

        public void TDelete(ContactUs entity)
        {
            _contactUsDal.Delete(entity);
        }

        public ContactUs TGetById(int id)
        {
            return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetList()
        {
            return _contactUsDal.GetAll();
        }

        public void TUpdate(ContactUs entity)
        {
            _contactUsDal.Update(entity);
        }
    }
}
