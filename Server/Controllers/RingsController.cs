using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLeepApnea.Server.Data;
using SLeepApnea.Shared.Domain;

namespace SLeepApnea.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ring>>> GetRings()
        {
            return await _context.Rings.ToListAsync();
        }

        // GET: api/Rings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ring>> GetRing(int id)
        {
            var ring = await _context.Rings.FindAsync(id);

            if (ring == null)
            {
                return NotFound();
            }

            return ring;
        }

        // PUT: api/Rings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRing(int id, Ring ring)
        {
            if (id != ring.Id)
            {
                return BadRequest();
            }

            _context.Entry(ring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RingExists(id))
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

        // POST: api/Rings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ring>> PostRing(Ring ring)
        {
            _context.Rings.Add(ring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRing", new { id = ring.Id }, ring);
        }

        // DELETE: api/Rings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRing(int id)
        {
            var ring = await _context.Rings.FindAsync(id);
            if (ring == null)
            {
                return NotFound();
            }

            _context.Rings.Remove(ring);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RingExists(int id)
        {
            return _context.Rings.Any(e => e.Id == id);
        }
    }
}
