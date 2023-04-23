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
    public class TiposCoberturaSueloController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposCoberturaSueloController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoCoberturaSueloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCoberturaSuelo>>> GetTipoCoberturaSuelos()
        {
          if (_context.TipoCoberturaSuelos == null)
          {
              return NotFound();
          }
            return await _context.TipoCoberturaSuelos.ToListAsync();
        }

        // GET: api/TipoCoberturaSueloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCoberturaSuelo>> GetTipoCoberturaSuelo(int id)
        {
          if (_context.TipoCoberturaSuelos == null)
          {
              return NotFound();
          }
            var tipoCoberturaSuelo = await _context.TipoCoberturaSuelos.FindAsync(id);

            if (tipoCoberturaSuelo == null)
            {
                return NotFound();
            }

            return tipoCoberturaSuelo;
        }

        // PUT: api/TipoCoberturaSueloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCoberturaSuelo(int id, TipoCoberturaSuelo tipoCoberturaSuelo)
        {
            if (id != tipoCoberturaSuelo.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoCoberturaSuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCoberturaSueloExists(id))
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

        // POST: api/TipoCoberturaSueloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCoberturaSuelo>> PostTipoCoberturaSuelo(TipoCoberturaSuelo tipoCoberturaSuelo)
        {
          if (_context.TipoCoberturaSuelos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoCoberturaSuelos'  is null.");
          }
            _context.TipoCoberturaSuelos.Add(tipoCoberturaSuelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoCoberturaSueloExists(tipoCoberturaSuelo.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoCoberturaSuelo", new { id = tipoCoberturaSuelo.CodigoSiex }, tipoCoberturaSuelo);
        }

        // DELETE: api/TipoCoberturaSueloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCoberturaSuelo(int id)
        {
            if (_context.TipoCoberturaSuelos == null)
            {
                return NotFound();
            }
            var tipoCoberturaSuelo = await _context.TipoCoberturaSuelos.FindAsync(id);
            if (tipoCoberturaSuelo == null)
            {
                return NotFound();
            }

            _context.TipoCoberturaSuelos.Remove(tipoCoberturaSuelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCoberturaSueloExists(int id)
        {
            return (_context.TipoCoberturaSuelos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
