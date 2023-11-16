using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAllComments()
        {
            return Ok(_commentRepository.GetAllComments());
        }
        [HttpGet("CommentBook")]
        public ActionResult<IEnumerable<Comment>> GetCommentByBookId(int bookId)
        {
            return Ok(_commentRepository.GetCommentByBookId(bookId));
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            var comment = _commentRepository.GetCommentById(id);
            if (comment == null)
                return NotFound();

            return comment;
        }

        [HttpPost]
        public ActionResult<int> CreateComment(Comment comment)
        {
            var id = _commentRepository.InsertComment(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id, comment });
        }
        

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, Comment comment)
        {
            if (id != comment.Comment_Id)
                return BadRequest();

            _commentRepository.UpdateComment(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentRepository.GetCommentById(id);
            if (comment == null)
                return NotFound();

            _commentRepository.DeleteComment(id);
            return NoContent();
        }
    }
}
