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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog TGetByID(int id)   //bu id blog controllerdaki tdelete içindeki id karşılık geliyor
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }
        public List<Blog> GetListWithCategoryByWriterBM(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);  // Kategorinin id yerine adının getirilmesi için
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        { 
            _blogDal.Delete(t);  // t parametresine karşılık olarak gelen değer blogvaluedan gelen değer (blogcontroller)
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public Blog GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
