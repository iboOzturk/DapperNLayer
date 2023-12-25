using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
