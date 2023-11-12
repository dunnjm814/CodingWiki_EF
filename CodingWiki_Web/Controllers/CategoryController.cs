using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            // pass Application db Context from program.cs with dependency injection
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if(id == null || id ==0)
            {
                //create
                return View(obj);
            }
            //edit
            // If Id not found exception will be thrown, use FirstOrDefault to avoid this and throw NotFound()
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if(ModelState.IsValid)
            {
                if(obj.CategoryId == 0)
                {
                    //Create
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //Update
                    // Update doesnt have an Async method. this also updates ALL properties (cumbersome for objects with many properties)
                    _db.Categories.Update(obj);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // if model state is not valid, return to view
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category obj = new();
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new List<Category>();
            for(int i = 0; i <2; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            // use Add range to batch your db inserts
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(c => c.CategoryId).Take(2);
            // use remove range to batch remove statements
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(c => c.CategoryId).Take(5);
            // use remove range to batch remove statements
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
