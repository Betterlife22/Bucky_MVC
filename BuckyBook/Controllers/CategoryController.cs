using Microsoft.AspNetCore.Mvc;

namespace BuckyBook.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
