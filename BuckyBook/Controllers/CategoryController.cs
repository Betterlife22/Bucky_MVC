using BuckyBook.Data;
using BuckyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuckyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext db)
        {
            _dbContext= db;
        }
        public IActionResult Index()
        {
            // vao database lấy list ra gán vào list objCategory để từ đó ngang bằng vs select *
            List<Category> objCategory= _dbContext.Categories.ToList();
            return View(objCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
