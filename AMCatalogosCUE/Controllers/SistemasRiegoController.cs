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
    public class SistemasRiegoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public SistemasRiegoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/SistemaRiegoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SistemaRiego>>> GetSistemaRiegos()
        {
          if (_context.SistemaRiegos == null)
          {
              return NotFound();
          }
            return await _context.SistemaRiegos.ToListAsync();
        }

        // GET: api/SistemaRiegoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SistemaRiego>> GetSistemaRiego(int id)
        {
          if (_context.SistemaRiegos == null)
          {
              return NotFound();
          }
            var sistemaRiego = await _context.SistemaRiegos.FindAsync(id);

            if (sistemaRiego == null)
            {
                return NotFound();
            }

            return sistemaRiego;
        }

        // PUT: api/SistemaRiegoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemaRiego(int id, SistemaRiego sistemaRiego)
        {
            if (id != sistemaRiego.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(sistemaRiego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaRiegoExists(id))
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

        // POST: api/SistemaRiegoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SistemaRiego>> PostSistemaRiego(SistemaRiego sistemaRiego)
        {
          if (_context.SistemaRiegos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.SistemaRiegos'  is null.");
          }
            _context.SistemaRiegos.Add(sistemaRiego);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SistemaRiegoExists(sistemaRiego.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSistemaRiego", new { id = sistemaRiego.CodigoSiex }, sistemaRiego);
        }

        // DELETE: api/SistemaRiegoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemaRiego(int id)
        {
            if (_context.SistemaRiegos == null)
            {
                return NotFound();
            }
            var sistemaRiego = await _context.SistemaRiegos.FindAsync(id);
            if (sistemaRiego == null)
            {
                return NotFound();
            }

            _context.SistemaRiegos.Remove(sistemaRiego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SistemaRiegoExists(int id)
        {
            return (_context.SistemaRiegos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
