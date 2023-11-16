using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext()
        {

        }
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options) { }
       
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<LeaderBoard> Leaders { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserBook> userBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookStore"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ 1-nhiều Book và Author
            modelBuilder.Entity<Book>()
              .HasOne(b => b.Author)
              .WithMany(a => a.Books)
              .HasForeignKey(b => b.AuthorId);

            // Cấu hình quan hệ n-1 Book và Category
            modelBuilder.Entity<Book>()
              .HasOne(b => b.Category)
              .WithMany(c => c.Books)
              .HasForeignKey(b => b.CategoryId);

            // Cấu hình quan hệ 1-nhiều Book và Chapter
            modelBuilder.Entity<Book>()
              .HasMany(b => b.Chapters)
              .WithOne(c => c.Book)
              .HasForeignKey(c => c.Book_Id)
              .OnDelete(DeleteBehavior.Cascade); // Xóa hết Chapter khi xóa Book

            // Cấu hình quan hệ 1-nhiều Book và Comment 
            modelBuilder.Entity<Book>()
              .HasMany(b => b.Comments)
              .WithOne(c => c.Book)
              .HasForeignKey(c => c.Book_id)
              .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ n-n User và Book
            modelBuilder.Entity<UserBook>()
              .HasKey(ub => new { ub.User_Id, ub.Book_Id }); // Khóa chính composite

            modelBuilder.Entity<UserBook>()
              .HasOne(ub => ub.User)
              .WithMany(u => u.UserBooks)
              .HasForeignKey(ub => ub.User_Id);

            modelBuilder.Entity<UserBook>()
              .HasOne(ub => ub.Book)
              .WithMany(b => b.UserBook)
              .HasForeignKey(ub => ub.Book_Id);
            // Cấu hình quan hệ 1-nhiều User và Comment
            modelBuilder.Entity<User>()
              .HasMany(u => u.Comments)
              .WithOne(c => c.User)
              .HasForeignKey(c => c.User_Id)
              .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ n-n User và Role  
            modelBuilder.Entity<UserRole>()
              .HasKey(ur => new { ur.User_Id, ur.Role_Id });

            modelBuilder.Entity<UserRole>()
              .HasOne(ur => ur.User)
              .WithMany(u => u.UseRoles)
              .HasForeignKey(ur => ur.User_Id);

            modelBuilder.Entity<UserRole>()
              .HasOne(ur => ur.Role)
              .WithMany(r => r.UseRoles)
              .HasForeignKey(ur => ur.Role_Id);

            // Cấu hình quan hệ 1-nhiều Book và Rating
            modelBuilder.Entity<Book>()
              .HasMany(b => b.Ratings)
              .WithOne(r => r.Book)
              .HasForeignKey(r => r.Book_Id);

            // Cấu hình quan hệ 1-1 Book và Leaderboard
            modelBuilder.Entity<Book>()
              .HasOne(b => b.Leaderboards)
              .WithOne(l => l.Book)
              .HasForeignKey<LeaderBoard>(l => l.BookId);
        }

    }
}
