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
        public DbSet<Genre> Genres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // remove local db name before pushing to git please
            optionsBuilder.UseSqlServer("Server=<serverName>;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Catcher in the Rye", ISBN = "123456", Price = 10.99m},
                new Book { BookId = 2, Title = "Lord of the Rings", ISBN = "987654", Price = 15.99m}
            );
            var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Book 3", ISBN = "456123", Price = 16.50m},
                new Book { BookId = 4, Title = "Book 4", ISBN = "556123", Price = 17.50m},
                new Book { BookId = 5, Title = "Book 5", ISBN = "656123", Price = 18.50m}
            };
            modelBuilder.Entity<Book>().HasData(bookList);
        }
    }
}
