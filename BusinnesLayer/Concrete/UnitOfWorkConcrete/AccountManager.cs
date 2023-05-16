using BusinnesLayer.Abstract.AbstractUnitOfWork;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete.UnitOfWorkConcrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public AccountManager(IAccountDal accountDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _accountDal = accountDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public Account TGetById(int id)
        {
            return _accountDal.GetById(id);
        }

        public void TInsert(Account entity)
        {
            _accountDal.Insert(entity);
            _unitOfWorkDal.Save();
        }

        public void TMultiUpdate(List<Account> entities)
        {
            _accountDal.MultiUpdate(entities);
            _unitOfWorkDal.Save();
        }

        public void TUpdate(Account entity)
        {
            _accountDal.Update(entity);
            _unitOfWorkDal.Save();
        }
    }
}
