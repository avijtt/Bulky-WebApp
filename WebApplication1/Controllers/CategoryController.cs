using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
                }
        public IActionResult Index()
        {
            List<Category> objCategoryList =  _db.categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Category obj) //make obj object to create new data 
        {
            if (obj.Name == obj.DispalyOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot same as Name");
            }
           if(ModelState.IsValid)
            {
                //keep track what to change
                _db.categories.Add(obj);
                //save in database
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");   
            }
           return View();
            

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();

            }
            Category? objCategoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);
            if (objCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(objCategoryFromDb);

        }   
     
        [HttpPost]
        public ActionResult Edit(Category obj) //make obj object to create new data 
        {
            if (obj.Name == obj.DispalyOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot same as Name");
            }
            if (ModelState.IsValid)
            {
                //keep track what to change
                _db.categories.Update(obj);
                //save in database
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Category? objCategoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);
            if (objCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(objCategoryFromDb);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int? id) //make obj object to create new data 
        {
            Category? obj = _db.categories.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
                //keep track what to change
                _db.categories.Remove(obj);
                //save in database
                _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            


        }
    }
}
