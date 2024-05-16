using BuckyBook.Data;
using BuckyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if(obj.name==obj.displayOrder.ToString()) {
                ModelState.AddModelError("name","The displayOrder can not exactly match the name");
            }
            if(ModelState.IsValid)
            {

           
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
                TempData["success"] = "Category is created successfully !";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==0 || id==null)
            {
                return NotFound();
            }
            Category category= _dbContext.Categories.Find(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
           
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(obj);
                _dbContext.SaveChanges();
                TempData["update"] = "Category is updated successfully !";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _dbContext.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _dbContext.Remove(obj);
            _dbContext.SaveChanges();
            TempData["delete"] = "Category is removed successfully !";
            return RedirectToAction("Index");
            
           
        }
    }
}
