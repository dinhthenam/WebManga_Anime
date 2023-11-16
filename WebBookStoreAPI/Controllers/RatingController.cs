using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rating>> GetAllRatings()
        {
            return Ok(_ratingRepository.GetAllRatings());
        }

        [HttpGet("{id}")]
        public ActionResult<Rating> GetRatingById(int id)
        {
            var rating = _ratingRepository.GetRatingById(id);
            if (rating == null)
                return NotFound();

            return rating;
        }

        [HttpPost]
        public ActionResult<int> CreateRating(Rating rating)
        {
            var id = _ratingRepository.InsertRating(rating);
            return CreatedAtAction(nameof(GetRatingById), new { id, rating });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRating(int id, Rating rating)
        {
            if (id != rating.Rating_Id)
                return BadRequest();

            _ratingRepository.UpdateRating(rating);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int id)
        {
            var rating = _ratingRepository.GetRatingById(id);
            if (rating == null)
                return NotFound();

            _ratingRepository.DeleteRating(id);
            return NoContent();
        }
    }
}
