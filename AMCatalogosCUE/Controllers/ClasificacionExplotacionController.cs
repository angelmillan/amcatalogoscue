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
    public class ClasificacionExplotacionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ClasificacionExplotacionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ClasificacionExplotacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasificacionExplotacion>>> GetClasificacionExplotacions()
        {
          if (_context.ClasificacionExplotacions == null)
          {
              return NotFound();
          }
            return await _context.ClasificacionExplotacions.ToListAsync();
        }

        // GET: api/ClasificacionExplotacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasificacionExplotacion>> GetClasificacionExplotacion(int id)
        {
          if (_context.ClasificacionExplotacions == null)
          {
              return NotFound();
          }
            var clasificacionExplotacion = await _context.ClasificacionExplotacions.FindAsync(id);

            if (clasificacionExplotacion == null)
            {
                return NotFound();
            }

            return clasificacionExplotacion;
        }

        // PUT: api/ClasificacionExplotacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasificacionExplotacion(int id, ClasificacionExplotacion clasificacionExplotacion)
        {
            if (id != clasificacionExplotacion.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(clasificacionExplotacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasificacionExplotacionExists(id))
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

        // POST: api/ClasificacionExplotacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClasificacionExplotacion>> PostClasificacionExplotacion(ClasificacionExplotacion clasificacionExplotacion)
        {
          if (_context.ClasificacionExplotacions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ClasificacionExplotacions'  is null.");
          }
            _context.ClasificacionExplotacions.Add(clasificacionExplotacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClasificacionExplotacionExists(clasificacionExplotacion.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClasificacionExplotacion", new { id = clasificacionExplotacion.CodigoSiex }, clasificacionExplotacion);
        }

        // DELETE: api/ClasificacionExplotacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasificacionExplotacion(int id)
        {
            if (_context.ClasificacionExplotacions == null)
            {
                return NotFound();
            }
            var clasificacionExplotacion = await _context.ClasificacionExplotacions.FindAsync(id);
            if (clasificacionExplotacion == null)
            {
                return NotFound();
            }

            _context.ClasificacionExplotacions.Remove(clasificacionExplotacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasificacionExplotacionExists(int id)
        {
            return (_context.ClasificacionExplotacions?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
