using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMCatalogosCUE.Models;

namespace AMCatalogosCUE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenpController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public SenpController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/Senps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Senp>>> GetSenps()
        {
          if (_context.Senps == null)
          {
              return NotFound();
          }
            return await _context.Senps.ToListAsync();
        }

        // GET: api/Senps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Senp>> GetSenp(int id)
        {
          if (_context.Senps == null)
          {
              return NotFound();
          }
            var senp = await _context.Senps.FindAsync(id);

            if (senp == null)
            {
                return NotFound();
            }

            return senp;
        }

        // PUT: api/Senps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSenp(int id, Senp senp)
        {
            if (id != senp.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(senp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SenpExists(id))
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

        // POST: api/Senps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Senp>> PostSenp(Senp senp)
        {
          if (_context.Senps == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.Senps'  is null.");
          }
            _context.Senps.Add(senp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SenpExists(senp.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSenp", new { id = senp.CodigoSiex }, senp);
        }

        // DELETE: api/Senps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSenp(int id)
        {
            if (_context.Senps == null)
            {
                return NotFound();
            }
            var senp = await _context.Senps.FindAsync(id);
            if (senp == null)
            {
                return NotFound();
            }

            _context.Senps.Remove(senp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SenpExists(int id)
        {
            return (_context.Senps?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
