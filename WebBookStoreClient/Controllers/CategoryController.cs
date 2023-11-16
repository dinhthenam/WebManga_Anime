using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebBookStoreClient.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:5000/api/Category");
            var categories = await response.Content.ReadFromJsonAsync<List<Category>>();

            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5000/api/Category/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            var category = await response.Content.ReadFromJsonAsync<Category>();
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            // Assume you have logic to handle creating a category
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5000/api/Category", category);

            // Check if the request is successful
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // Handle the case where the request is not successful (e.g., validation error)
            // You might want to add error handling logic here
            return View("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5000/api/Category/{id}");
            var category = await response.Content.ReadFromJsonAsync<Category>();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update2(Category category)
        {
            var id = category.Category_Id;
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:5000/api/Category/{id}", category);

            // Check if the request is successful
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // Handle the case where the request is not successful (e.g., validation error)
            // You might want to add error handling logic here
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:5000/api/Category/{id}");
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
