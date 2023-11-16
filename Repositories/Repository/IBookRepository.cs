using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        int InsertBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        IEnumerable<Book> IsTrending();
        IEnumerable<Book> RandomTrending();
        IEnumerable<Book> Mostviewed();
        IEnumerable<Book> GetLastedBook();
        IEnumerable<Book> ActionBook();
        IEnumerable<Book> AdventureBook();

    }

}
