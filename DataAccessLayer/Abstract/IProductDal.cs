using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> GetOldestProductsAsync();
        Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync();
    }
}
