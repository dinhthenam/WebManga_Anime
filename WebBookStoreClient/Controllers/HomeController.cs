using BusinessObject.Models;
using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using WebBookStoreClient.Models;
using WebBookStoreAPI.DTO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;

namespace WebBookStoreClient.Controllers
{

    public class HomeController : Controller
    {
        private readonly HttpClient _httpClientFactory;
        private readonly BookStoreContext _context;
        public HomeController(HttpClient httpClientFactory, BookStoreContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            try
            {
                // Sử dụng ViewData thay vì ViewBag để truyền dữ liệu từ Controller đến View
                ViewData["Categories"] = new List<Category>();
                ViewData["Trending"] = new List<Book>();
                ViewData["MostView"] = new List<Book>();
                ViewData["LastBook"] = new List<Book>();
                ViewData["Action"] = new List<Book>();
                ViewData["Adventure"] = new List<Book>();

                // Gọi API Category để lấy danh sách thể loại
                var categoryResponse = await _httpClientFactory.GetAsync("https://localhost:5000/api/Category");
                if (categoryResponse.IsSuccessStatusCode)
                {
                    using (var stream = await categoryResponse.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var categoryData = new JsonSerializer().Deserialize<IEnumerable<Category>>(jsonReader);
                        ViewData["Categories"] = categoryData;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("Error calling Category API");
                }

                // Gọi API Book để lấy danh sách sách Trending
                var trendingBookResponse = await _httpClientFactory.GetAsync("https://localhost:5000/api/Book/Trending");
                if (trendingBookResponse.IsSuccessStatusCode)
                {
                    using (var stream = await trendingBookResponse.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var trendingBookData = new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
                        ViewData["Trending"] = trendingBookData;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("Error calling Trending Books API");
                }
                var actionBook = await _httpClientFactory.GetAsync("https://localhost:5000/api/Book/Action");
                if (actionBook.IsSuccessStatusCode)
                {
                    using (var stream = await actionBook.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var actionBookData = new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
                        ViewData["Action"] = actionBookData;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("Error calling Action Books API");

                }
                var adventureBook = await _httpClientFactory.GetAsync("https://localhost:5000/api/Book/Adventure");
                if (adventureBook.IsSuccessStatusCode)
                {
                    using (var stream = await adventureBook.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var adventureBookData = new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
                        ViewData["Adventure"] = adventureBookData;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("Error calling Adventure Books API");

                }
                var Lastbook = await _httpClientFactory.GetAsync("https://localhost:5000/api/Book/MostView");
                if (Lastbook.IsSuccessStatusCode)
                {
                    using (var stream = await Lastbook.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var LastbookData = new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
                        ViewData["LastBook"] = LastbookData;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("Error calling Last Books API");
                }

                // Gọi API Book để lấy danh sách sách Most Viewed
                var mostViewedBookResponse = await _httpClientFactory.GetAsync("https://localhost:5000/api/Book/MostView");
                if (mostViewedBookResponse.IsSuccessStatusCode)
                {
                    using (var stream = await mostViewedBookResponse.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var mostViewedBookData = new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
                        ViewData["MostView"] = mostViewedBookData;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("Error calling Most Viewed Books API");
                }

                var token = HttpContext.Session.GetString("Token");
                if (token != null && token.Length > 0)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    if (jsonToken != null)
                    {
                        // Access claims from the JWT token
                        var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
                        var userName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
                        var userEmail = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

                        var response = await _httpClientFactory.GetAsync($"https://localhost:5000/api/User/{userId}");
                        var user = await response.Content.ReadFromJsonAsync<User>();

                        ViewData["User"] = user;
                    }
                    else
                    {
                        Console.WriteLine("Invalid token format");
                    }
                }

                return View();
            }
            catch (HttpRequestException ex)
            {
                // Xử lý khi có lỗi trong quá trình gọi API
                // Ví dụ: Ghi log lỗi, hiển thị thông báo lỗi, chuyển hướng trang lỗi, v.v.
                return View("Error");
            }
        }
        
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string Email_address, string Password)
        {

          
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5000/"); 

                var loginModel = new LoginModel
                {
                    User_Email = Email_address,
                    User_Password = Password
                };
               
                
                var response = await client.PostAsJsonAsync("api/Auth/Login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var token = JObject.Parse(responseContent)["token"].ToString();
                    ViewBag.Categories = new List<Category>();
                    ViewBag.Book = new List<Book>();

                    HttpContext.Session.SetString("Token", token);

                    

             //       HttpContext.User.Identity.IsAuthenticated = true;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password";
                    return View("Login");
                }
            }
        }

        [AllowAnonymous]
        [Route("Logup")]
        [HttpGet]
        public IActionResult Logup()
        {
            return View();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Logup(User user)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5000/");

                var response = await client.PostAsJsonAsync("api/Auth/signup", user);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    return View("Index");
                }
            }
        }
    }
}