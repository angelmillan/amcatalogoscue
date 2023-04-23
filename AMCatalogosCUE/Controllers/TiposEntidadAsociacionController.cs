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
    public class TiposEntidadAsociacionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposEntidadAsociacionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoEntidadAsociacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEntidadAsociacion>>> GetTipoEntidadAsociacions()
        {
          if (_context.TipoEntidadAsociacions == null)
          {
              return NotFound();
          }
            return await _context.TipoEntidadAsociacions.ToListAsync();
        }

        // GET: api/TipoEntidadAsociacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEntidadAsociacion>> GetTipoEntidadAsociacion(int id)
        {
          if (_context.TipoEntidadAsociacions == null)
          {
              return NotFound();
          }
            var tipoEntidadAsociacion = await _context.TipoEntidadAsociacions.FindAsync(id);

            if (tipoEntidadAsociacion == null)
            {
                return NotFound();
            }

            return tipoEntidadAsociacion;
        }

        // PUT: api/TipoEntidadAsociacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEntidadAsociacion(int id, TipoEntidadAsociacion tipoEntidadAsociacion)
        {
            if (id != tipoEntidadAsociacion.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoEntidadAsociacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEntidadAsociacionExists(id))
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

        // POST: api/TipoEntidadAsociacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoEntidadAsociacion>> PostTipoEntidadAsociacion(TipoEntidadAsociacion tipoEntidadAsociacion)
        {
          if (_context.TipoEntidadAsociacions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoEntidadAsociacions'  is null.");
          }
            _context.TipoEntidadAsociacions.Add(tipoEntidadAsociacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoEntidadAsociacionExists(tipoEntidadAsociacion.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoEntidadAsociacion", new { id = tipoEntidadAsociacion.CodigoSiex }, tipoEntidadAsociacion);
        }

        // DELETE: api/TipoEntidadAsociacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEntidadAsociacion(int id)
        {
            if (_context.TipoEntidadAsociacions == null)
            {
                return NotFound();
            }
            var tipoEntidadAsociacion = await _context.TipoEntidadAsociacions.FindAsync(id);
            if (tipoEntidadAsociacion == null)
            {
                return NotFound();
            }

            _context.TipoEntidadAsociacions.Remove(tipoEntidadAsociacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEntidadAsociacionExists(int id)
        {
            return (_context.TipoEntidadAsociacions?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
