using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebBookStoreClient.Controllers
{
    public class CommentController : Controller
    {
        private readonly HttpClient _httpClient;

        public CommentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int Userid,int Bookid, string content)
        {
            var comment = new Comment
            {
                User_Id = Userid,
                Book_id = Bookid,
                content = content,
                CreatedDate = DateTime.Now,
                User = null,
                Book = null
            };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:5000/api/Comment", comment);

            if (response.IsSuccessStatusCode)
            {
                // Xử lý thành công, có thể thêm mã logic xử lý sau khi tạo comment thành công
                return RedirectToAction("Details","Book");
            }
            else
            {
                // Xử lý khi có lỗi, có thể thêm mã logic xử lý sau khi gặp lỗi
                return View("Error");
            }
        }
    }
}
