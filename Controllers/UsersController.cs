using Microsoft.AspNetCore.Mvc;
using Twitter_clone_backend.Data.Interfaces;
using Twitter_clone_backend.Models.DTO;

namespace Twitter_clone_backend.Controllers
{
    [Controller]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repository;

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            try
            {
                List<UserDTO> tweets = await _repository.GetAllUsersAsync();
                return Ok(tweets);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{handle}")]
        public async Task<ActionResult<TweetDTO>> GetUserByHandle(string handle)
        {
            try
            {
                UserDTO user = await _repository.GetUserByHandleAsync(handle);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
