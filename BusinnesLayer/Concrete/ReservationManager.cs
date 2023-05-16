using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetListWithAppUserId(int id)
        {
            return _reservationDal.GetListWithAppUserId(id);
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            return _reservationDal.GetListWithReservationByAccepted(id);
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            return _reservationDal.GetListWithReservationByPrevious(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void TAdd(Reservation entity)
        {
            _reservationDal.Insert(entity);
        }

        public void TDelete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetAll();
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
