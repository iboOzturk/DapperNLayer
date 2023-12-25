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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;   
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public bool Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _categoryDal.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public bool Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
    }
}
