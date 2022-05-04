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
    public class DataCollectedsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DataCollectedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DataCollecteds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataCollected>>> GetDataCollecteds()
        {
            return await _context.DataCollecteds.ToListAsync();
        }

        // GET: api/DataCollecteds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataCollected>> GetDataCollected(int id)
        {
            var dataCollected = await _context.DataCollecteds.FindAsync(id);

            if (dataCollected == null)
            {
                return NotFound();
            }

            return dataCollected;
        }

        // PUT: api/DataCollecteds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataCollected(int id, DataCollected dataCollected)
        {
            if (id != dataCollected.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataCollected).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataCollectedExists(id))
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

        // POST: api/DataCollecteds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataCollected>> PostDataCollected(DataCollected dataCollected)
        {
            _context.DataCollecteds.Add(dataCollected);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataCollected", new { id = dataCollected.Id }, dataCollected);
        }

        // DELETE: api/DataCollecteds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataCollected(int id)
        {
            var dataCollected = await _context.DataCollecteds.FindAsync(id);
            if (dataCollected == null)
            {
                return NotFound();
            }

            _context.DataCollecteds.Remove(dataCollected);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataCollectedExists(int id)
        {
            return _context.DataCollecteds.Any(e => e.Id == id);
        }
    }
}
