using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;

namespace WebBookStoreClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient _httpClient;

        public BookController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:5000/api/Book");
            var Books = await response.Content.ReadFromJsonAsync<List<Book>>();

            return View(Books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5000/api/Book/{id}");
            ViewData["Categories"] = new List<Category>();
            ViewData["Chapter"] = new List<Chapter>();
            ViewData["RandomTrending"] = new List<Book>();
            ViewData["Comment"] = new List<CommentViewModel>();

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            
                var commentResponse = await _httpClient.GetAsync($"https://localhost:5000/api/Comment/CommentBook?bookId={id}");
            if (commentResponse.IsSuccessStatusCode)
            {
                using (var stream = await commentResponse.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var CommentData = new JsonSerializer().Deserialize<IEnumerable<CommentViewModel>>(jsonReader);
                    ViewData["Comment"] = CommentData;
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("Error calling Comment API");
            }
            var categoryResponse = await _httpClient.GetAsync("https://localhost:5000/api/Category");
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
            var RandomTrending = await _httpClient.GetAsync("https://localhost:5000/api/Book/RandomTrending");
            if (RandomTrending.IsSuccessStatusCode)
            {
                using (var stream = await RandomTrending.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var LastbookData = new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
                    ViewData["RandomTrending"] = LastbookData;
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("Error calling Last Books API");
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

                    var response2 = await _httpClient.GetAsync($"https://localhost:5000/api/User/{userId}");
                    var user = await response2.Content.ReadFromJsonAsync<User>();

                    ViewData["User"] = user;
                }
                else
                {
                    Console.WriteLine("Invalid token format");
                }
            }

            var book = await response.Content.ReadFromJsonAsync<Book>();
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5000/api/Book", book);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5000/api/Book/{id}");
            var book = await response.Content.ReadFromJsonAsync<Book>();

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Book book)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:5000/api/Category/{book.Book_Id}", book);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:5000/api/Book{id}");

            return RedirectToAction("Index");
        }
    }
}

