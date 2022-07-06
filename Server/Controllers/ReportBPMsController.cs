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
    public class ReportBPMsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportBPMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReportBPMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportBPM>>> GetReportBPMs()
        {
            return await _context.ReportBPMs.ToListAsync();
        }

        // GET: api/ReportBPMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportBPM>> GetReportBPM(int id)
        {
            var reportBPM = await _context.ReportBPMs.FindAsync(id);

            if (reportBPM == null)
            {
                return NotFound();
            }

            return reportBPM;
        }

        // PUT: api/ReportBPMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportBPM(int id, ReportBPM reportBPM)
        {
            if (id != reportBPM.ID)
            {
                return BadRequest();
            }

            _context.Entry(reportBPM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportBPMExists(id))
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

        // POST: api/ReportBPMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportBPM>> PostReportBPM(ReportBPM reportBPM)
        {
            _context.ReportBPMs.Add(reportBPM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportBPM", new { id = reportBPM.ID }, reportBPM);
        }

        // DELETE: api/ReportBPMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportBPM(int id)
        {
            var reportBPM = await _context.ReportBPMs.FindAsync(id);
            if (reportBPM == null)
            {
                return NotFound();
            }

            _context.ReportBPMs.Remove(reportBPM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportBPMExists(int id)
        {
            return _context.ReportBPMs.Any(e => e.ID == id);
        }
    }
}
