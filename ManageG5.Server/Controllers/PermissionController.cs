using ManageG5.Server;
using Microsoft.AspNetCore.Mvc;
using ManageG5.Server.Models;   

namespace ManageSystemAPI.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private static List<Permission> permissions = new List<Permission>();

        // GET: api/permission
        [HttpGet]
        public IActionResult GetPermissions()
        {
            return Ok(new { message = "Permission API is working!" });
        }

        // GET: api/permission/{id}
        [HttpGet("{id}")]
        public IActionResult GetPermission(Guid id)
        {
            var permission = permissions.FirstOrDefault(p => p.Id == id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        // POST: api/permission
        [HttpPost]
        public IActionResult CreatePermission([FromBody] Permission permission)
        {
            if (permission == null)
            {
                return BadRequest();
            }

            permission.Id = Guid.NewGuid(); // Ensure a unique ID is assigned
            permissions.Add(permission);
            return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permission);
        }

        // PUT: api/permission/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePermission(Guid id, [FromBody] Permission updatedPermission)
        {
            var permission = permissions.FirstOrDefault(p => p.Id == id);
            if (permission == null)
            {
                return NotFound();
            }

            permission.Name = updatedPermission.Name;
            permission.Roles = updatedPermission.Roles;  // Update roles
            return NoContent(); // Successfully updated
        }

        // DELETE: api/permission/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePermission(Guid id)
        {
            var permission = permissions.FirstOrDefault(p => p.Id == id);
            if (permission == null)
            {
                return NotFound();
            }

            permissions.Remove(permission);
            return NoContent(); // Successfully deleted
        }
    }
}
