using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        public List<Reservation> GetListWithReservationByWaitApproval(int id);
        public List<Reservation> GetListWithReservationByPrevious(int id);
        public List<Reservation> GetListWithReservationByAccepted(int id);
        public List<Reservation> GetListWithAppUserId(int id);
    }
}
