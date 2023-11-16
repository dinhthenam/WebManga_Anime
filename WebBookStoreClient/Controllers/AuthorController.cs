using Microsoft.AspNetCore.Mvc;

namespace WebBookStoreClient.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
