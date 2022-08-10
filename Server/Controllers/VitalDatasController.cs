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
    public class VitalDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VitalDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VitalDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VitalData>>> GetVitalDatas()
        {
            return await _context.VitalDatas.ToListAsync();
        }

        // GET: api/VitalDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VitalData>> GetVitalData(int id)
        {
            var vitalData = await _context.VitalDatas.FindAsync(id);

            if (vitalData == null)
            {
                return NotFound();
            }

            return vitalData;
        }

		// PUT: api/VitalDatas/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutVitalData(int id, VitalData vitalData)
		{
			//if (id != vitalData.ID)
			//{
			//    return BadRequest();
			//}
			_context.Entry(vitalData).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!VitalDataExists(id))
				//{
				//	return NotFound();
				//}
				//else
				//{
				//	throw;
				//}
			}

			return NoContent();
		}
		[HttpPut]
        public async Task<IActionResult> PutVitalDatas(VitalData vitalData)
		{
            _context.Entry(vitalData).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
            }
            //_context.VitalDatas.Update(vitalData);
            //         await _context.SaveChangesAsync();
            return NoContent();
            //return CreatedAtAction("GetVitalData", new { id = vitalData.ID }, vitalData);
        }

        // POST: api/VitalDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VitalData>> PostVitalData(VitalData vitalData)
        {
            _context.VitalDatas.Add(vitalData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVitalData", new { id = vitalData.ID }, vitalData);
        }

        // DELETE: api/VitalDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitalData(int id)
        {
            var vitalData = await _context.VitalDatas.FindAsync(id);
            if (vitalData == null)
            {
                return NotFound();
            }

            _context.VitalDatas.Remove(vitalData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VitalDataExists(int id)
        {
            return _context.VitalDatas.Any(e => e.ID == id);
        }
    }
}
