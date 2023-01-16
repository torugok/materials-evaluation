using MaterialsEvaluation.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityPropertiesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public QualityPropertiesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualityProperty>>> GetQualityProperties()
        {
            if (_context.QualityProperties == null)
            {
                return NotFound();
            }

            return await _context.QualityProperties.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QualityProperty>> GetQualityProperty(long id)
        {
            if (_context.QualityProperties == null)
            {
                return NotFound();
            }

            var qualityProperty = await _context.QualityProperties.FindAsync(id);

            if (qualityProperty == null)
            {
                return NotFound();
            }

            return qualityProperty;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<QualityProperty>> PutQualityProperty(
            Guid id,
            QualityProperty qualityProperty
        )
        {
            if (id != qualityProperty.Id)
            {
                return BadRequest();
            }

            _context.Entry(qualityProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualityPropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return qualityProperty;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QualityProperty>> PostQualityProperty(
            QualityProperty qualityProperty
        )
        {
            _context.QualityProperties.Add(qualityProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetQualityProperty),
                new { id = qualityProperty.Id },
                qualityProperty
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualityProperty(Guid id)
        {
            if (_context.QualityProperties == null)
            {
                return NotFound();
            }

            var qualityProperty = await _context.QualityProperties.FindAsync(id);
            if (qualityProperty == null)
            {
                return NotFound();
            }

            _context.QualityProperties.Remove(qualityProperty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualityPropertyExists(Guid id)
        {
            return (_context.QualityProperties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
