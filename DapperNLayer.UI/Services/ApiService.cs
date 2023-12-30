using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DapperNLayer.UI.Services
{
    public class LoginResponse
    {
        public string token { get; set; }
    }
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
            _httpClient.BaseAddress = new Uri("https://localhost:44358/api/");
        }


        public async Task<string> LoginAsync(string username, string password)
        {
            var loginModel = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("Auth/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<LoginResponse>(result).token;

                return token;
            }

            return null;

        }

        public async Task<List<Item>> GetMyItemsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("Items/my-items");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<Item>>(result);
                return items;
            }

            return null;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:44331/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var result=await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(result);
            }
            return null;
        }
        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:44331/api/Products/ProductWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(result); 
            }
            return null;
        }
    }
}
