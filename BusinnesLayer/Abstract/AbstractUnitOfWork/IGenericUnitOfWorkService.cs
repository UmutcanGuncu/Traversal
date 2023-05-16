using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract.AbstractUnitOfWork
{
    public interface IGenericUnitOfWorkService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TMultiUpdate(List<T> entities);
        T TGetById(int id);
    }
}
