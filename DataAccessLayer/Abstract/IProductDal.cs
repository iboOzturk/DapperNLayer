using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> GetOldestProductsAsync();
        Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync();
    }
}
