using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManageG5.Server.Models;

namespace ManageG5.Server.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        private static List<User> users = new List<User>();

        // GET: api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            users.Add(new User { Username = "inaHogan007", Id ="admin",Email = "aa@ggg.com",PhoneNumber="",Role = new Role() { Name = "Admin", Description ="" }, RoleId ="1",Name = "",  });
       
            return Ok(users);
        }

        // GET: api/user/{id} for check login
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            user.CreatedAt = DateTime.UtcNow;
            users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.RoleId = updatedUser.RoleId;
            user.Role = updatedUser.Role;
            user.UpdatedAt = DateTime.UtcNow;
            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
