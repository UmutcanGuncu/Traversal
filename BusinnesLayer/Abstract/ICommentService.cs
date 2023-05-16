using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment> 
    {
        List<Comment> GetListByFilter(int id);
        List<Comment> GetListCommentWithDestination();
        List<Comment> GetListCommentWithDestinationAndUser(int id);
    }
}
