using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILeaderBoardRepository _leaderBoardRepository;

        public LeaderBoardController(ILeaderBoardRepository leaderBoardRepository)
        {
            _leaderBoardRepository = leaderBoardRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeaderBoard>> GetAllLeaderBoards()
        {
            return Ok(_leaderBoardRepository.GetAllLeaderBoards());
        }

        [HttpGet("{id}")]
        public ActionResult<LeaderBoard> GetLeaderBoardById(int id)
        {
            var leaderBoard = _leaderBoardRepository.GetLeaderBoardById(id);
            if (leaderBoard == null)
                return NotFound();

            return leaderBoard;
        }

        [HttpPost]
        public ActionResult<int> CreateLeaderBoard(LeaderBoard leaderBoard)
        {
            var id = _leaderBoardRepository.InsertLeaderBoard(leaderBoard);
            return CreatedAtAction(nameof(GetLeaderBoardById), new { id, leaderBoard });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLeaderBoard(int id, LeaderBoard leaderBoard)
        {
            if (id != leaderBoard.LeaderBoard_Id)
                return BadRequest();

            _leaderBoardRepository.UpdateLeaderBoard(leaderBoard);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLeaderBoard(int id)
        {
            var leaderBoard = _leaderBoardRepository.GetLeaderBoardById(id);
            if (leaderBoard == null)
                return NotFound();

            _leaderBoardRepository.DeleteLeaderBoard(id);
            return NoContent();
        }
    }
}
