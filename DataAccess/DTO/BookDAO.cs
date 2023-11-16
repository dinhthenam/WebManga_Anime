using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class BookDAO
    {
        private readonly BookStoreContext _dbContext;

        public BookDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            var books = new Book();
            books.Comments = _dbContext.Comments.Where(c => c.Book_id == bookId).ToList();
            books.Chapters = _dbContext.Chapters.Where(c => c.Book_Id == bookId).ToList();
            return books;
        }

        public int InsertBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Book_Id;
        }

        public void UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Book> IsTrending()
        {
            return _dbContext.Books.Where(b => b.IsTrending == 0).Take(6).ToList();
        }
        public IEnumerable<Book> RandomTrending()
        {
            return _dbContext.Books.Where(b => b.IsTrending == 0).OrderBy(b => Guid.NewGuid()).Take(5).ToList();
        }
        public IEnumerable<Book> GetLatestUpdatedBooks()
        {
            return _dbContext.Books
                            .Where(b => b.CreatedDate> DateTime.Now.AddMonths(-1))
                            .OrderByDescending(b => b.CreatedDate)
                            .Take(6)
                            .ToList();
        }
        public IEnumerable<Book> ActionBook()
        {
            int actionCategoryId = _dbContext.Categories
                                .Where(c => c.Category_Name == "Action")
                                .Select(c => c.Category_Id)
                                .FirstOrDefault();

            return _dbContext.Books
                 .Where(b => b.CategoryId == actionCategoryId)
                 .ToList();
        }
        public IEnumerable<Book> AdventureBook()
        {
            int AdventureCategoryId = _dbContext.Categories
                                .Where(c => c.Category_Name == "Adventure")
                                .Select(c => c.Category_Id)
                                .FirstOrDefault();

            return _dbContext.Books
                 .Where(b => b.CategoryId == AdventureCategoryId)
                 .ToList();
        }
        public IEnumerable<Book> MostViewed()
        {
            return _dbContext.Books.OrderByDescending(b => b.ViewCount).Take(5).ToList();
        }

        public void DeleteBook(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Book_Id == bookId);

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
    }

}
