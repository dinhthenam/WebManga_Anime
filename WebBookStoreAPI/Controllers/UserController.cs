using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userRepository.GetAllUsers());
        }
        [HttpGet("Roles")]
        public ActionResult<Role> GetRoles(int userId)
        {
            return _userRepository.GetUserRole(userId);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            return user;
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<User>> GetAllUsersBykeyword(string keyword)
        {
            return Ok(_userRepository.GetUserByKeyword(keyword));
        }

        [HttpPost]
        public ActionResult<int> CreateUser(User user)
        {
            var id = _userRepository.InsertUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id, user });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.User_Id)
                return BadRequest();

            _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
