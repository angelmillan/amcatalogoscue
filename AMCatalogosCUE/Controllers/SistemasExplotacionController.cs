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
    public class SistemasExplotacionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public SistemasExplotacionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/SistemaExplotacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SistemaExplotacion>>> GetSistemaExplotacions()
        {
          if (_context.SistemaExplotacions == null)
          {
              return NotFound();
          }
            return await _context.SistemaExplotacions.ToListAsync();
        }

        // GET: api/SistemaExplotacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SistemaExplotacion>> GetSistemaExplotacion(string id)
        {
          if (_context.SistemaExplotacions == null)
          {
              return NotFound();
          }
            var sistemaExplotacion = await _context.SistemaExplotacions.FindAsync(id);

            if (sistemaExplotacion == null)
            {
                return NotFound();
            }

            return sistemaExplotacion;
        }

        // PUT: api/SistemaExplotacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemaExplotacion(string id, SistemaExplotacion sistemaExplotacion)
        {
            if (id != sistemaExplotacion.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(sistemaExplotacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaExplotacionExists(id))
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

        // POST: api/SistemaExplotacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SistemaExplotacion>> PostSistemaExplotacion(SistemaExplotacion sistemaExplotacion)
        {
          if (_context.SistemaExplotacions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.SistemaExplotacions'  is null.");
          }
            _context.SistemaExplotacions.Add(sistemaExplotacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SistemaExplotacionExists(sistemaExplotacion.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSistemaExplotacion", new { id = sistemaExplotacion.CodigoSiex }, sistemaExplotacion);
        }

        // DELETE: api/SistemaExplotacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemaExplotacion(string id)
        {
            if (_context.SistemaExplotacions == null)
            {
                return NotFound();
            }
            var sistemaExplotacion = await _context.SistemaExplotacions.FindAsync(id);
            if (sistemaExplotacion == null)
            {
                return NotFound();
            }

            _context.SistemaExplotacions.Remove(sistemaExplotacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SistemaExplotacionExists(string id)
        {
            return (_context.SistemaExplotacions?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
