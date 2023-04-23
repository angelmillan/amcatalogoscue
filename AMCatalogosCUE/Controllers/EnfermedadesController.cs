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
    public class EnfermedadesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public EnfermedadesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/Enfermedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfermedade>>> GetEnfermedades()
        {
          if (_context.Enfermedades == null)
          {
              return NotFound();
          }
            return await _context.Enfermedades.ToListAsync();
        }

        // GET: api/Enfermedades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermedade>> GetEnfermedade(int id)
        {
          if (_context.Enfermedades == null)
          {
              return NotFound();
          }
            var enfermedade = await _context.Enfermedades.FindAsync(id);

            if (enfermedade == null)
            {
                return NotFound();
            }

            return enfermedade;
        }

        // PUT: api/Enfermedades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermedade(int id, Enfermedade enfermedade)
        {
            if (id != enfermedade.Id)
            {
                return BadRequest();
            }

            _context.Entry(enfermedade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermedadeExists(id))
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

        // POST: api/Enfermedades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enfermedade>> PostEnfermedade(Enfermedade enfermedade)
        {
          if (_context.Enfermedades == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.Enfermedades'  is null.");
          }
            _context.Enfermedades.Add(enfermedade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnfermedadeExists(enfermedade.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnfermedade", new { id = enfermedade.Id }, enfermedade);
        }

        // DELETE: api/Enfermedades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfermedade(int id)
        {
            if (_context.Enfermedades == null)
            {
                return NotFound();
            }
            var enfermedade = await _context.Enfermedades.FindAsync(id);
            if (enfermedade == null)
            {
                return NotFound();
            }

            _context.Enfermedades.Remove(enfermedade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfermedadeExists(int id)
        {
            return (_context.Enfermedades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
