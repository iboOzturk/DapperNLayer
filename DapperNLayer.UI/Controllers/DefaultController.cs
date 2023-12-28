using DapperNLayer.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperNLayer.UI.Controllers
{
    [Authorize]

    public class DefaultController : Controller
    {
		private readonly ApiService _apiService;
		 CategoryService _categoryService=new CategoryService();

        public DefaultController(ApiService apiService)
        {
            _apiService = apiService;
            
        }

        public IActionResult Index()
        {
            return View();
        }
		public async Task<IActionResult> MyItems()
		{
			string token = HttpContext.Session.GetString("JwtToken");

			if (string.IsNullOrEmpty(token))
			{
				return RedirectToAction("Index","Login");
			}

			var items = await _apiService.GetMyItemsAsync(token);

			return View(items);
		}
		public async Task<IActionResult> ProductList()
		{
			var result = await _apiService.GetProductsAsync();
			return View(result);
		}
        public async Task<IActionResult> ProductWithCategoryList()
        {
            var result = await _apiService.GetProductsWithCategoryAsync();
            return View(result);
        }
		public IActionResult CategoryList()
		{
			var result = _categoryService.GetCategories();
			return View(result);
		}
        public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
}
