using Azure;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using PagedList.Core;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace WebBookStoreClient.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respone = await _httpClient.GetAsync($"https://localhost:5000/api/User");
            var users = await respone.Content.ReadFromJsonAsync<List<User>>();
            return View(users);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Index(int? page, string searchString)
        {

            // Xử lý phân trang
            int pageNumber = page ?? 1;
            int pageSize = 2;

            string url = "https://localhost:5000/api/User";

            // Thêm searchString nếu có
            if (!string.IsNullOrEmpty(searchString))
            {
                url += "?keyword=" + searchString;
            }

            // Lấy danh sách users
            var response = await _httpClient.GetAsync(url);
            var users = await response.Content.ReadFromJsonAsync<List<User>>();

            // Phân trang
            int totalCount = users.Count;
            int pageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            List<User> pagedUsers = users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            // Đóng gói kết quả
            IPagedList<User> pagedList = new StaticPagedList<User>(pagedUsers, pageNumber, pageSize, totalCount);

            // Dữ liệu cho View
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            ViewBag.HasPreviousPage = pageNumber > 1;
            ViewBag.HasNextPage = pageNumber < pageCount;

            return View(pagedList);

        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5000/api/User/{id}");
            var user = await response.Content.ReadFromJsonAsync<User>();

            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(User user)
        {
            user.CreatedDate = DateTime.Now;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5000/api/User", user);

         //   response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5000/api/User/{id}");
            var user = await response.Content.ReadFromJsonAsync<User>();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update2(User user)
        {
            var id = user.User_Id;
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:5000/api/User/{id}", user);
           
           if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            };

            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _httpClient.DeleteAsync($"https://localhost:5000/api/User/{id}");
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
