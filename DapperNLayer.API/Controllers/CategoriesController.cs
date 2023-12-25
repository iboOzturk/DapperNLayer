using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperNLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());

        [HttpGet]
        public IActionResult GetAll()
        {
            var result=categoryManager.GetAll();
            return Ok(result);
        }
        [HttpGet("{ProductId}")]
        public IActionResult Get(int ProductId)
        {
            var result = categoryManager.GetById(ProductId);
            return Ok(result);
        }
      

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = categoryManager.Delete(id);

            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            var result = categoryManager.Add(category);

            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            var result = categoryManager.Update(category);

            return Ok(result);
        }
    }
}
