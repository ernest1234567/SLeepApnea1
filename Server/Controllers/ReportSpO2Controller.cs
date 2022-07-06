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
    public class ReportSpO2Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportSpO2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReportSpO2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportSpO2>>> GetReportSpO2s()
        {
            return await _context.ReportSpO2s.ToListAsync();
        }

        // GET: api/ReportSpO2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportSpO2>> GetReportSpO2(int id)
        {
            var reportSpO2 = await _context.ReportSpO2s.FindAsync(id);

            if (reportSpO2 == null)
            {
                return NotFound();
            }

            return reportSpO2;
        }

        // PUT: api/ReportSpO2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportSpO2(int id, ReportSpO2 reportSpO2)
        {
            if (id != reportSpO2.ID)
            {
                return BadRequest();
            }

            _context.Entry(reportSpO2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportSpO2Exists(id))
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

        // POST: api/ReportSpO2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportSpO2>> PostReportSpO2(ReportSpO2 reportSpO2)
        {
            _context.ReportSpO2s.Add(reportSpO2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportSpO2", new { id = reportSpO2.ID }, reportSpO2);
        }

        // DELETE: api/ReportSpO2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportSpO2(int id)
        {
            var reportSpO2 = await _context.ReportSpO2s.FindAsync(id);
            if (reportSpO2 == null)
            {
                return NotFound();
            }

            _context.ReportSpO2s.Remove(reportSpO2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportSpO2Exists(int id)
        {
            return _context.ReportSpO2s.Any(e => e.ID == id);
        }
    }
}
