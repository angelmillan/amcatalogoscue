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
    public class TiposFertilizacionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposFertilizacionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoFertilizacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFertilizacion>>> GetTipoFertilizacions()
        {
          if (_context.TipoFertilizacions == null)
          {
              return NotFound();
          }
            return await _context.TipoFertilizacions.ToListAsync();
        }

        // GET: api/TipoFertilizacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFertilizacion>> GetTipoFertilizacion(int id)
        {
          if (_context.TipoFertilizacions == null)
          {
              return NotFound();
          }
            var tipoFertilizacion = await _context.TipoFertilizacions.FindAsync(id);

            if (tipoFertilizacion == null)
            {
                return NotFound();
            }

            return tipoFertilizacion;
        }

        // PUT: api/TipoFertilizacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoFertilizacion(int id, TipoFertilizacion tipoFertilizacion)
        {
            if (id != tipoFertilizacion.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoFertilizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoFertilizacionExists(id))
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

        // POST: api/TipoFertilizacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoFertilizacion>> PostTipoFertilizacion(TipoFertilizacion tipoFertilizacion)
        {
          if (_context.TipoFertilizacions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoFertilizacions'  is null.");
          }
            _context.TipoFertilizacions.Add(tipoFertilizacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoFertilizacionExists(tipoFertilizacion.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoFertilizacion", new { id = tipoFertilizacion.CodigoSiex }, tipoFertilizacion);
        }

        // DELETE: api/TipoFertilizacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoFertilizacion(int id)
        {
            if (_context.TipoFertilizacions == null)
            {
                return NotFound();
            }
            var tipoFertilizacion = await _context.TipoFertilizacions.FindAsync(id);
            if (tipoFertilizacion == null)
            {
                return NotFound();
            }

            _context.TipoFertilizacions.Remove(tipoFertilizacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoFertilizacionExists(int id)
        {
            return (_context.TipoFertilizacions?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
