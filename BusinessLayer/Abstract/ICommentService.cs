using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
         // void CategoryDelete(Comment comment);
        //void CategoryUpdate(Comment comment);
        List<Comment> GetList(int id);
        //Comment GetByID(int id);
    }
}
