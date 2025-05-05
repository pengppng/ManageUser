using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageG5.Server.Models;

namespace ManageG5.Server.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context){ _context = context; }
        private static List<User> users = new List<User>();

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/user/{id} for check login
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            user.Id = GenerateCustomId();
            // if (await _context.Users.AnyAsync(u => u.Id == user.Id))
            //     return Conflict("Duplicate ID");


            if (user == null)
                return BadRequest("User data is required");

            
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        private string GenerateCustomId()
        {
            return "u" + Guid.NewGuid().ToString();
        }


        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.RoleId = updatedUser.RoleId;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
