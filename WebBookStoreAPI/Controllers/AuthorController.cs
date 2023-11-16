using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);

            if (author == null)
                return NotFound();

            return author;
        }

        [HttpPost]
        public ActionResult<int> CreateAuthor(Author author)
        {
            var id = _authorRepository.InsertAuthor(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = id, author });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Author_Id)
                return BadRequest();

            _authorRepository.UpdateAuthor(author);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
                return NotFound();

            _authorRepository.DeleteAuthor(id);
            return NoContent();
        }
    }
}
