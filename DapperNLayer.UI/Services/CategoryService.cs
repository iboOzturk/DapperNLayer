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

        public bool AddCategory(Category category)
        {
            var result = categoryManager.Add(category);
            return result;
        }
        public bool RemoveCategory(int id)
        {
            var result=categoryManager.Delete(id);
            return result;
        }
        public bool UpdateCategory(Category category)
        {
            var result = categoryManager.Update(category);
            return result;
        }
        public Category GetByIdCategory(int id)
        {
            var category = categoryManager.GetById(id);
            return category;
        }

    }
}
