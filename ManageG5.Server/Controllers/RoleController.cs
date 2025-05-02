using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageG5.Server.Models;

namespace ManageG5.Server.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RoleController(AppDbContext context) { _context = context; }
        private static List<Role> roles = new List<Role>();

        // GET: api/role
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        }

    } 


