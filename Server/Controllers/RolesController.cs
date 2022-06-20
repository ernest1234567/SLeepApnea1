﻿using System;
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
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoless()
        {
            return await _context.Roless.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRoles(int id)
        {
            var roles = await _context.Roless.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, Roles roles)
        {
            if (id != roles.ID)
            {
                return BadRequest();
            }

            _context.Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roles>> PostRoles(Roles roles)
        {
            _context.Roless.Add(roles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoles", new { id = roles.ID }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var roles = await _context.Roless.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.Roless.Remove(roles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesExists(int id)
        {
            return _context.Roless.Any(e => e.ID == id);

        }
    }
}
