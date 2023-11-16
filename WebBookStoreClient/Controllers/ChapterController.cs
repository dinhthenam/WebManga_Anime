using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebBookStoreClient.Controllers
{
    public class ChapterController : Controller
    {
        private readonly HttpClient _httpClient;

        public ChapterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int chapterId, int bookId)
        {

            ViewData["Image"] = new List<string>();

            try
            {
                var chapterResponse = await _httpClient.GetAsync($"https://localhost:5000/api/Chapter/GetChapter?Chapterid={chapterId}&bookId={bookId}");

                if (!chapterResponse.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var imageResponse = await _httpClient.GetAsync($"https://localhost:5000/api/Chapter/image?chapterId={chapterId}");

                if (!imageResponse.IsSuccessStatusCode)
                {
                  
                    ViewData["Image"] = new List<string>();
                }
                else
                {
                    var images = await imageResponse.Content.ReadFromJsonAsync<List<string>>();
                    ViewData["Image"] = images ?? new List<string>();
                }

                var chapter = await chapterResponse.Content.ReadFromJsonAsync<Chapter>();

                return View(chapter);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
