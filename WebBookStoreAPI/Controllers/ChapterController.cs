using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterRepository _chapterRepository;

        public ChapterController(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Chapter>> GetAllChapters()
        {
            return Ok(_chapterRepository.GetAllChapters());
        }

        [HttpGet("GetChapter")]
        public ActionResult<Chapter> GetChapterById(int Chapterid,int bookId)
        {
            var chapter = _chapterRepository.GetChapterById(Chapterid,bookId);
            if (chapter == null)
                return NotFound();

            return chapter;
        }
        [HttpGet("image")]
        public ActionResult<List<String>> GetImage(int chapterId)
         {
            var image = _chapterRepository.GetImage(chapterId);
            if (image == null)
            {
                return NotFound();
            }
            return image;
        }

        [HttpPost]
        public ActionResult<int> CreateChapter(Chapter chapter)
        {
            var id = _chapterRepository.InsertChapter(chapter);
            return CreatedAtAction(nameof(GetChapterById), new { id, chapter });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChapter(int id, Chapter chapter)
        {
            if (id != chapter.Chapter_Id)
                return BadRequest();

            _chapterRepository.UpdateChapter(chapter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChapter(int chapterid, int bookid)
        {
            var chapter = _chapterRepository.GetChapterById(chapterid,bookid);
            if (chapter == null)
                return NotFound();

            _chapterRepository.DeleteChapter(chapterid);
            return NoContent();
        }
    }
}