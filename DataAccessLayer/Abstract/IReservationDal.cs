using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id); //bekleyen
        List<Reservation> GetListWithReservationByAccepted(int id); //Kabul Edilen
        List<Reservation> GetListWithReservationByPrevious(int id); //Geçmiş Rezervasyonlar
        List<Reservation> GetListWithAppUserId(int id); //appuser ıd ye göre listele
    }
}
