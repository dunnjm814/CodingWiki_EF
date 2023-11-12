// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

////using(ApplicationDbContext context = new())
////{
//// we dont need either of these since we know our schema and database migrations are already run
////    context.Database.EnsureCreated();
////    if(context.Database.GetPendingMigrations().Count() > 0)
////    {
////        context.Database.Migrate();
////        //run any pending migrations
////    }
////}
////GetAllBooks();
////AddBook();
////GetBook();
////GetBookByProperty();
////GetBookByPrimaryKey();
////GetBooksByISBN();
////OrderBooksByTitle();
////PaginateMyBooks();
////UpdateBook();
//DeleteBook();
//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();

//    foreach (var book in books)
//    {
//        Console.WriteLine($"{book.Title} - {book.ISBN}");
//    }
//}

//void AddBook() 
//{
//    Book book = new() {Title = "New EF Core Book", ISBN = "12312311", Price = 10.93m, Publisher_Id=1 };
//    using var context = new ApplicationDbContext();
//    var books = context.Books.Add(book);
//    // Book not added to DB unless we SaveChanges()
//    context.SaveChanges(); 
//}

//void GetBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        Book book = context.Books.FirstOrDefault();
//        Console.WriteLine($"{book.Title} - {book.ISBN}");
//    } catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }

//}

//void GetBookByProperty()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        //IQueryable<Book> books = context.Books.Where(u => u.Publisher_Id == 3);
//        //foreach (var book in books) {
//        //    Console.WriteLine($"{book.Title} - {book.ISBN}");
//        //}
//        //var book = context.Books.Where(u => u.Publisher_Id == 3 && u.Price >= 15).FirstOrDefault();
//        // if we know were only expecting one record all logic in where can be passed into first or default
//        var id = 3;
//        var book = context.Books.FirstOrDefault(u => u.Publisher_Id == id);
//        Console.WriteLine($"{book.Title} - {book.ISBN}");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void GetBookByPrimaryKey()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        Book book = context.Books.Find(6);
//        Console.WriteLine($"{book.Title} - {book.ISBN}");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void GetBooksByISBN()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        //var books = context.Books.Where(u => u.ISBN.Contains("12"));
//        var books = context.Books.Where(u => EF.Functions.Like(u.ISBN, "12%"));
//        foreach(var book in books)
//        {
//            Console.WriteLine($"{book.Title} - {book.ISBN}");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void OrderBooksByTitle()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = context.Books.OrderBy(u=>u.Title);
//        foreach (var book in books)
//        {
//            Console.WriteLine($"{book.Title} - {book.ISBN}");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void PaginateMyBooks()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = context.Books.Skip(0).Take(2);
//        foreach (var book in books)
//        {
//            Console.WriteLine($"{book.Title} - {book.ISBN}");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void UpdateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();

//        var book = context.Books.Find(1);
//        book.ISBN = "UpdatedISBN1234";
//        context.SaveChanges();

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void DeleteBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.Find(5);
//        context.Books.Remove(book);
//        context.SaveChanges();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}