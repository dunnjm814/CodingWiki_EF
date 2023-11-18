using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            // pass Application db Context from program.cs with dependency injection
            _db = db;
        }
        public IActionResult Index()
        {
            //List<Book> objList = _db.Books.ToList();
            List<Book> objList = _db.Books.Include(u => u.Publisher)
                                          .Include(u=>u.AuthorBookMap)
                                          .ThenInclude(u=>u.Author).ToList();
            // Include adds innerjoin on Publishers
            //foreach (var obj in objList)
            //{
            ////   //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
            ////   //explicit loading the publisher. Better loading of child entities due to less database calls
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //    //Use collection because of many-many relation
            //    _db.Entry(obj).Collection(u=>u.AuthorBookMap).Load();   
            ////  // most efficient loading is eager loading
            ////  // query for one type (book) loads related entities in same query (publisher, author, etc)
            ////  // eager loading achieved through .Include()
            ////  // Includes MUST be called before Filtering methods like firstordefault()
            ////  // use ThenInclude() to reference child objects, useful for single trip to database when working with Many-many relations
            ////  //
            //}
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();
            //projection of publishers to new SelectListItem anonymous object.
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if(id == null || id ==0)
            {
                //create
                return View(obj);
            }
            //edit
            // If Id not found exception will be thrown, use FirstOrDefault to avoid this and throw NotFound()
            obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
           
            if(obj.Book.BookId== 0)
            {
                //Create
                await _db.Books.AddAsync(obj.Book);
            }
            else
            {
                //Update
                // Update doesnt have an Async method. this also updates ALL properties (cumbersome for objects with many properties)
                _db.Books.Update(obj.Book);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();

            //edit
            //obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            //join book to book detail with eager loading
            obj = _db.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                //create
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                //update
                _db.BookDetails.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();
            obj = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ManageAuthors(int id) 
        {
            AuthorBookVM obj = new()
            {
                AuthorBookList = _db.AuthorBookMaps.Include(u => u.Author)
                                                   .Include(u => u.Book)
                                                   .Where(u => u.Book_Id == id),
                AuthorBook = new()
                {
                    Book_Id = id
                },
                Book = _db.Books.FirstOrDefault(u => u.BookId == id)
            };

            List<int> tempListOfAssignedAuthors = obj.AuthorBookList.Select(u=>u.Author_Id).ToList();
            //NOT IN Clause
            //We want a list of all authors not in tempList

            var tempList = _db.Authors.Where(u => !tempListOfAssignedAuthors.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });
            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(AuthorBookVM authorBookVM)
        {
            if(authorBookVM.AuthorBook.Book_Id != 0 && authorBookVM.AuthorBook.Author_Id != 0)
            {
                _db.AuthorBookMaps.Add(authorBookVM.AuthorBook);
                _db.SaveChanges();  
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = authorBookVM.AuthorBook.Book_Id});
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, AuthorBookVM authorBookVM)
        {
            int bookId = authorBookVM.Book.BookId;
            AuthorBookMap authorBookMap = _db.AuthorBookMaps.FirstOrDefault(
                u => u.Author_Id == authorId && u.Book_Id == bookId);


            _db.AuthorBookMaps.Remove(authorBookMap);
            _db.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> Playground()
        {
            IEnumerable<Book> BookList1 = _db.Books;
            var FilteredBook1 = BookList1.Where(b => b.Price > 50).ToList();

            IQueryable<Book> BookList2 = _db.Books;
            var fileredBook2 = BookList2.Where(b => b.Price > 50).ToList();


            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }

    }
}
