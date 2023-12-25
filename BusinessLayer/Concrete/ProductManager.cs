using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public bool Add(Product entity)
        {
           return _productDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _productDal.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetOldestProductsAsync()
        {
            var result=_productDal.GetOldestProductsAsync();
            return result.Result;
        }

        public List<ProductWithCategoryDto> GetProductWithCategoryAsync()
        {
            var result=_productDal.GetProductWithCategoryAsync();
            return result.Result;
        }

        public bool Update(Product entity)
        {
            return _productDal.Update(entity);
        }

    }
}
