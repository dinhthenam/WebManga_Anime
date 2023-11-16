using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(_bookRepository.GetAllBooks());
        }
        [HttpGet("Trending")]
        public ActionResult<IEnumerable<Book>> IsTrending()
        {
            return Ok(_bookRepository.IsTrending());
        }
        [HttpGet("RandomTrending")]
        public ActionResult<IEnumerable<Book>> RandomTrending()
        {
            return Ok(_bookRepository.RandomTrending());
        }
        [HttpGet("MostView")]
        public ActionResult<IEnumerable<Book>> Mostviewed()
        {
            return Ok(_bookRepository.Mostviewed());
        }
        [HttpGet("LastedBook")]
        public ActionResult<IEnumerable<Book>> LastedBook()
        {
            return Ok(_bookRepository.GetLastedBook());
        }
        [HttpGet("Action")]
        public ActionResult<IEnumerable<Book>> ActionBook()
        {
            return Ok(_bookRepository.ActionBook());
        }
        [HttpGet("Adventure")]
        public ActionResult<IEnumerable<Book>> AdventureBook()
        {
            return Ok(_bookRepository.AdventureBook());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            return book;
        }

        [HttpPost]
        public ActionResult<int> CreateBook(Book book)
        {
            var id = _bookRepository.InsertBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id, book });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Book_Id)
                return BadRequest();

            _bookRepository.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
