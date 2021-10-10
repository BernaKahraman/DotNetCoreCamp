using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newLetterDal;

        public NewsLetterManager(INewsLetterDal newLetterDal)
        {
            _newLetterDal = newLetterDal;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newLetterDal.Insert(newsLetter);
        }
    }
}
