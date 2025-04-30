using ManageG5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManageG5.Server.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DocumentController : Controller
    {
        private static List<Document> documents = new List<Document>();

        // GET: api/document
        [HttpGet]
        public IActionResult GetDocuments()
        {
            return Ok(documents);
        }

        // GET: api/document/{id}
        [HttpGet("{id}")]
        public IActionResult GetDocument(string id)
        {
            var document = documents.FirstOrDefault(d => d.Id == id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        // POST: api/document
        [HttpPost]
        public IActionResult CreateDocument([FromBody] Document document)
        {
            if (document == null)
            {
                return BadRequest();
            }

            document.CreatedAt = DateTime.UtcNow;
            documents.Add(document);
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }

        // PUT: api/document/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDocument(string id, [FromBody] Document updatedDocument)
        {
            var document = documents.FirstOrDefault(d => d.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            document.Name = updatedDocument.Name;
            document.Description = updatedDocument.Description;
            document.CreatedAt = updatedDocument.CreatedAt; // You might want to handle this differently
            return NoContent();
        }

        // DELETE: api/document/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(string id)
        {
            var document = documents.FirstOrDefault(d => d.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            documents.Remove(document);
            return NoContent();
        }
    }
}
