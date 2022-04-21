using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DancePage.Model;
using DancePage.DataAccessUI;

namespace DancePage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersDataAccess dataAccess;

        public UsersController(IUsersDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(dataAccess.GetUsers());
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetEById(int userId)
        {
            var user = dataAccess.GetEById(userId);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            dataAccess.AddE(user);
            return Ok(dataAccess.GetUsers());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User e)
        {
            var user = dataAccess.GetEById(e.UserId);
            if (user == null)
                return NotFound("User not found");

            dataAccess.SaveEAsync(e);

            return Ok(dataAccess.GetUsers());
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<List<User>>> Delete(int userId)
        {
            var user = dataAccess.GetEById(userId);
            if (user == null)
                return NotFound("User not found");

            dataAccess.DeleteEAsync(userId);

            return Ok(dataAccess.GetUsers());
        }
    }
}
