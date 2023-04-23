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
    public class OrigenAguaRiegoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public OrigenAguaRiegoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/OrigenAguaRiegoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrigenAguaRiego>>> GetOrigenAguaRiegos()
        {
          if (_context.OrigenAguaRiegos == null)
          {
              return NotFound();
          }
            return await _context.OrigenAguaRiegos.ToListAsync();
        }

        // GET: api/OrigenAguaRiegoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrigenAguaRiego>> GetOrigenAguaRiego(int id)
        {
          if (_context.OrigenAguaRiegos == null)
          {
              return NotFound();
          }
            var origenAguaRiego = await _context.OrigenAguaRiegos.FindAsync(id);

            if (origenAguaRiego == null)
            {
                return NotFound();
            }

            return origenAguaRiego;
        }

        // PUT: api/OrigenAguaRiegoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigenAguaRiego(int id, OrigenAguaRiego origenAguaRiego)
        {
            if (id != origenAguaRiego.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(origenAguaRiego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigenAguaRiegoExists(id))
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

        // POST: api/OrigenAguaRiegoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrigenAguaRiego>> PostOrigenAguaRiego(OrigenAguaRiego origenAguaRiego)
        {
          if (_context.OrigenAguaRiegos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.OrigenAguaRiegos'  is null.");
          }
            _context.OrigenAguaRiegos.Add(origenAguaRiego);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrigenAguaRiegoExists(origenAguaRiego.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrigenAguaRiego", new { id = origenAguaRiego.CodigoSiex }, origenAguaRiego);
        }

        // DELETE: api/OrigenAguaRiegoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigenAguaRiego(int id)
        {
            if (_context.OrigenAguaRiegos == null)
            {
                return NotFound();
            }
            var origenAguaRiego = await _context.OrigenAguaRiegos.FindAsync(id);
            if (origenAguaRiego == null)
            {
                return NotFound();
            }

            _context.OrigenAguaRiegos.Remove(origenAguaRiego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrigenAguaRiegoExists(int id)
        {
            return (_context.OrigenAguaRiegos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
