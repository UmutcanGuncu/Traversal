using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

       

        public void TAdd(Comment entity)
        {
            
            _commentDal.Insert(entity);

        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetAll();
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public List<Comment> GetListByFilter(int id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationId == id);
        }

        public List<Comment> GetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }
    }
}
