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
    public class TipoSuperfPlantadaUvaVinificablesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TipoSuperfPlantadaUvaVinificablesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoSuperfPlantadaUvaVinificables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSuperfPlantadaUvaVinificable>>> GetTipoSuperfPlantadaUvaVinificables()
        {
          if (_context.TipoSuperfPlantadaUvaVinificables == null)
          {
              return NotFound();
          }
            return await _context.TipoSuperfPlantadaUvaVinificables.ToListAsync();
        }

        // GET: api/TipoSuperfPlantadaUvaVinificables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSuperfPlantadaUvaVinificable>> GetTipoSuperfPlantadaUvaVinificable(int id)
        {
          if (_context.TipoSuperfPlantadaUvaVinificables == null)
          {
              return NotFound();
          }
            var tipoSuperfPlantadaUvaVinificable = await _context.TipoSuperfPlantadaUvaVinificables.FindAsync(id);

            if (tipoSuperfPlantadaUvaVinificable == null)
            {
                return NotFound();
            }

            return tipoSuperfPlantadaUvaVinificable;
        }

        // PUT: api/TipoSuperfPlantadaUvaVinificables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSuperfPlantadaUvaVinificable(int id, TipoSuperfPlantadaUvaVinificable tipoSuperfPlantadaUvaVinificable)
        {
            if (id != tipoSuperfPlantadaUvaVinificable.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoSuperfPlantadaUvaVinificable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSuperfPlantadaUvaVinificableExists(id))
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

        // POST: api/TipoSuperfPlantadaUvaVinificables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoSuperfPlantadaUvaVinificable>> PostTipoSuperfPlantadaUvaVinificable(TipoSuperfPlantadaUvaVinificable tipoSuperfPlantadaUvaVinificable)
        {
          if (_context.TipoSuperfPlantadaUvaVinificables == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoSuperfPlantadaUvaVinificables'  is null.");
          }
            _context.TipoSuperfPlantadaUvaVinificables.Add(tipoSuperfPlantadaUvaVinificable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoSuperfPlantadaUvaVinificableExists(tipoSuperfPlantadaUvaVinificable.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoSuperfPlantadaUvaVinificable", new { id = tipoSuperfPlantadaUvaVinificable.CodigoSiex }, tipoSuperfPlantadaUvaVinificable);
        }

        // DELETE: api/TipoSuperfPlantadaUvaVinificables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSuperfPlantadaUvaVinificable(int id)
        {
            if (_context.TipoSuperfPlantadaUvaVinificables == null)
            {
                return NotFound();
            }
            var tipoSuperfPlantadaUvaVinificable = await _context.TipoSuperfPlantadaUvaVinificables.FindAsync(id);
            if (tipoSuperfPlantadaUvaVinificable == null)
            {
                return NotFound();
            }

            _context.TipoSuperfPlantadaUvaVinificables.Remove(tipoSuperfPlantadaUvaVinificable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoSuperfPlantadaUvaVinificableExists(int id)
        {
            return (_context.TipoSuperfPlantadaUvaVinificables?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
