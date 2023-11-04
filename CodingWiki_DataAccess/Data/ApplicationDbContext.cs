using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // remove local db name before pushing to git please
            optionsBuilder.UseSqlServer("Server=<localDb>;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<AuthorBookMap>().HasKey(u => new { u.Author_Id, u.Book_Id});

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Catcher in the Rye", ISBN = "123456", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Lord of the Rings", ISBN = "987654", Price = 15.99m, Publisher_Id = 2 }
            );
            var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Book 3", ISBN = "456123", Price = 16.50m, Publisher_Id=1},
                new Book { BookId = 4, Title = "Book 4", ISBN = "556123", Price = 17.50m, Publisher_Id=2},
                new Book { BookId = 5, Title = "Book 5", ISBN = "656123", Price = 18.50m, Publisher_Id=3}
            };
            modelBuilder.Entity<Book>().HasData(bookList);
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2", Location = "New York"},
                new Publisher { Publisher_Id = 3, Name = "Pub 3", Location = "Dallas" }
            );
        }
    }
}
