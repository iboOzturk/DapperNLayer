using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Net.Http;

namespace DapperNLayer.UI.Services
{
    public class CategoryService
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());

        public IEnumerable<Category> GetCategories()   
        {
            var result = categoryManager.GetAll();
            return result;
        }

    }
}
