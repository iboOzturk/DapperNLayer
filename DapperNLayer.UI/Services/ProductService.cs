using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DapperNLayer.UI.Services
{
    public class ProductService
    {
        ProductManager productManager = new ProductManager(new ProductRepository());
        public IEnumerable<Product> GetProducts()
        {
            var result = productManager.GetAll();
            return result;
        }
        public void DeleteProduct(int id)
        {
             productManager.Delete(id);
          
        }

        public Product GetProductById2(int id) 
        {  
            return productManager.GetById(id); 
        }
       
        public bool UpdateProduct(Product product)
        {
            var result=productManager.Update(product);
            return result;
        }
    }
}
