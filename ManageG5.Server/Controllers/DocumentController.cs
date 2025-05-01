using ManageG5.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ManageG5.Server.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DocumentController(AppDbContext context) { _context = context; }
        // private static List<Document> documents = new List<Document>();

        // GET: api/document
        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _context.Documents.ToListAsync();
            return Ok(documents);
        }

        // GET: api/document/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocument(string id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        // POST: api/document
        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] Document document)
        {
            if (document == null)
            {
                return BadRequest();
            }

            document.Id = Guid.NewGuid().ToString(); // Set a new ID for the document
            document.CreatedAt = DateTime.UtcNow;
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }
        
        // PUT: api/document/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(string id, [FromBody] Document updatedDocument)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            document.Name = updatedDocument.Name;
            document.Description = updatedDocument.Description;
            document.CreatedAt = updatedDocument.CreatedAt; // You might want to handle this differently
            
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/document/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(string id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
