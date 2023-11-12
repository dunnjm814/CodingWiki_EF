using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<AuthorBookMap> AuthorBookMaps { get; set; }

        //rename to Fluent_BookDetails in modelBuilder
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }

        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_AuthorBookMap> Fluent_AuthorBookMaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // remove local db name before pushing to git please
            // commenting out since we are passing in service for web application. this was hard coded previously for Console app learnings
            //optionsBuilder.UseSqlServer("Server=<LocalDb>;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
            //    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information );
            //On configuring is within the base class as a options override, for MVC since we are passing connection string to the app builder
            // and injecting the context in the app builder, we need to pass that option to the constructor in this class
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<AuthorBookMap>().HasKey(u => new { u.Author_Id, u.Book_Id});

            // all this stuff can be consolidated into a configuration folder. Look at FluentConfig Folder for respective config files
            //modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            //modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            //modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
            //modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
            //modelBuilder.Entity<Fluent_BookDetail>().HasOne(b => b.Book).WithOne(u => u.BookDetail)
            //                                        .HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);

            //modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(50);
            //modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired();
            //modelBuilder.Entity<Fluent_Book>().HasKey(u => u.BookId);
            //modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);
            //modelBuilder.Entity<Fluent_Book>().HasOne(u => u.Publisher).WithMany(u => u.Books)
            //                                  .HasForeignKey(u => u.Publisher_Id);

            //modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);
            //modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();

            //modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
            //modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
            //modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).HasMaxLength(50);
            //modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
            //modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);
            //// many - many table
            //modelBuilder.Entity<Fluent_AuthorBookMap>().HasKey(u => new { u.Author_Id, u.Book_Id });
            //modelBuilder.Entity<Fluent_AuthorBookMap>().HasOne(u => u.Book).WithMany(u => u.AuthorBookMap)
            //                                    .HasForeignKey(u => u.Book_Id);
            //modelBuilder.Entity<Fluent_AuthorBookMap>().HasOne(u => u.Author).WithMany(u => u.AuthorBookMap)
            //                                    .HasForeignKey(u => u.Author_Id);
            // apply the configurations to modelBuilder
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorBookMappingConfig());

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
                new Publisher { Publisher_Id = 2, Name = "Pub 2", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3", Location = "Dallas" }
            );

        }
    }
}
