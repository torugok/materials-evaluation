using MaterialsEvaluation.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityVisionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public QualityVisionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/QualityVisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualityVision>>> GetQualityVisions()
        {
            if (_context.QualityVisions == null)
            {
                return NotFound();
            }

            return await _context.QualityVisions.ToListAsync();
        }

        // GET: api/QualityVisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QualityVision>> GetQualityVision(long id)
        {
            if (_context.QualityVisions == null)
            {
                return NotFound();
            }

            var qualityVision = await _context.QualityVisions.FindAsync(id);

            if (qualityVision == null)
            {
                return NotFound();
            }

            return qualityVision;
        }

        // PUT: api/QualityVisions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQualityVision(long id, QualityVision qualityVision)
        {
            if (id != qualityVision.Id)
            {
                return BadRequest();
            }

            _context.Entry(qualityVision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualityVisionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QualityVisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QualityVision>> PostQualityVision(
            QualityVision qualityVision
        )
        {
            if (_context.QualityVisions == null)
            {
                return Problem("Entity set 'DatabaseContext.QualityVisions'  is null.");
            }

            _context.QualityVisions.Add(qualityVision);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetQualityVision",
                new { id = qualityVision.Id },
                qualityVision
            );
        }

        // DELETE: api/QualityVisions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualityVision(long id)
        {
            if (_context.QualityVisions == null)
            {
                return NotFound();
            }

            var qualityVision = await _context.QualityVisions.FindAsync(id);
            if (qualityVision == null)
            {
                return NotFound();
            }

            _context.QualityVisions.Remove(qualityVision);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualityVisionExists(long id)
        {
            return (_context.QualityVisions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
