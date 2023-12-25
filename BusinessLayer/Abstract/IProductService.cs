using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IProductService:IGenericService<Product>
    {
       List<Product> GetOldestProductsAsync();
       List<ProductWithCategoryDto> GetProductWithCategoryAsync();
    }
}
