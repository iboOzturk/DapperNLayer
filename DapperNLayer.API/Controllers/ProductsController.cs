using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperNLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductManager productManager = new ProductManager(new ProductRepository());

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = productManager.GetAll();
            return Ok(result);
        }
        [HttpGet("{ProductId}")]
        public IActionResult Get(int ProductId)
        {
            var result = productManager.GetById(ProductId);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public IActionResult OldestProducts()
        {
            var result = productManager.GetOldestProductsAsync();

            return Ok(result);
        }
        [HttpGet("[action]")]
        public IActionResult ProductWithCategory()
        {
            var result = productManager.GetProductWithCategoryAsync();

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = productManager.Delete(id);

            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            var result = productManager.Add(product);

            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var result = productManager.Update(product);

            return Ok(result);
        }
    }
}
