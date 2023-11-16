using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDAO _bookDAO;

        public BookRepository(BookDAO bookDAO)
        {
            _bookDAO = bookDAO;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDAO.GetAllBooks();
        }

        public Book GetBookById(int bookId)
        {
            return _bookDAO.GetBookById(bookId);
        }

        public int InsertBook(Book book)
        {
            return _bookDAO.InsertBook(book);
        }

        public void UpdateBook(Book book)
        {
            _bookDAO.UpdateBook(book);
        }

        public void DeleteBook(int bookId)
        {
            _bookDAO.DeleteBook(bookId);
        }

        public IEnumerable<Book> IsTrending()
        {
           return _bookDAO.IsTrending();
        }

        public IEnumerable<Book> Mostviewed()
        {
            return _bookDAO.MostViewed();
        }

        public IEnumerable<Book> GetLastedBook()
        {
            return _bookDAO.GetLatestUpdatedBooks();
        }
        public IEnumerable<Book> ActionBook()
        {
            return _bookDAO.ActionBook();
        }
        public IEnumerable<Book> AdventureBook()
        {
            return _bookDAO.AdventureBook();
        }

        public IEnumerable<Book> RandomTrending()
        {
            return _bookDAO.RandomTrending();
        }
    }

}
