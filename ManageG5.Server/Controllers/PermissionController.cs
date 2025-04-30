using ManageG5.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageG5.Server.Models;   

namespace ManageSystemAPI.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/permission
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _context.Permissions
                .Include(p => p.RolePermissions)
                .ToListAsync();
            return Ok(new { data = permissions, message = "Permissions retrieved successfully." });
        }

        // GET: api/permission/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission(Guid id)
        {
            var permission = await _context.Permissions
                .Include(p => p.RolePermissions)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        // POST: api/permission
        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] Permission permission)
        {
            if (permission == null)
                return BadRequest();

            permission.Id = Guid.NewGuid();
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permission);
        }

        // PUT: api/permission/{id}
        public async Task<IActionResult> UpdatePermission(Guid id, [FromBody] Permission updated)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
                return NotFound();

            permission.Name = updated.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/permission/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(Guid id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
                return NotFound();

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
