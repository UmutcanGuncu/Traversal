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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetAll();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
