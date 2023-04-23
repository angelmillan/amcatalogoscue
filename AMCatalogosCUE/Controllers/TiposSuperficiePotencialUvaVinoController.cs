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
    public class TiposSuperficiePotencialUvaVinoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposSuperficiePotencialUvaVinoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoSuperficiePotencialUvaVinoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSuperficiePotencialUvaVino>>> GetTipoSuperficiePotencialUvaVinos()
        {
          if (_context.TipoSuperficiePotencialUvaVinos == null)
          {
              return NotFound();
          }
            return await _context.TipoSuperficiePotencialUvaVinos.ToListAsync();
        }

        // GET: api/TipoSuperficiePotencialUvaVinoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSuperficiePotencialUvaVino>> GetTipoSuperficiePotencialUvaVino(int id)
        {
          if (_context.TipoSuperficiePotencialUvaVinos == null)
          {
              return NotFound();
          }
            var tipoSuperficiePotencialUvaVino = await _context.TipoSuperficiePotencialUvaVinos.FindAsync(id);

            if (tipoSuperficiePotencialUvaVino == null)
            {
                return NotFound();
            }

            return tipoSuperficiePotencialUvaVino;
        }

        // PUT: api/TipoSuperficiePotencialUvaVinoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSuperficiePotencialUvaVino(int id, TipoSuperficiePotencialUvaVino tipoSuperficiePotencialUvaVino)
        {
            if (id != tipoSuperficiePotencialUvaVino.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoSuperficiePotencialUvaVino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSuperficiePotencialUvaVinoExists(id))
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

        // POST: api/TipoSuperficiePotencialUvaVinoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoSuperficiePotencialUvaVino>> PostTipoSuperficiePotencialUvaVino(TipoSuperficiePotencialUvaVino tipoSuperficiePotencialUvaVino)
        {
          if (_context.TipoSuperficiePotencialUvaVinos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoSuperficiePotencialUvaVinos'  is null.");
          }
            _context.TipoSuperficiePotencialUvaVinos.Add(tipoSuperficiePotencialUvaVino);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoSuperficiePotencialUvaVinoExists(tipoSuperficiePotencialUvaVino.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoSuperficiePotencialUvaVino", new { id = tipoSuperficiePotencialUvaVino.CodigoSiex }, tipoSuperficiePotencialUvaVino);
        }

        // DELETE: api/TipoSuperficiePotencialUvaVinoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSuperficiePotencialUvaVino(int id)
        {
            if (_context.TipoSuperficiePotencialUvaVinos == null)
            {
                return NotFound();
            }
            var tipoSuperficiePotencialUvaVino = await _context.TipoSuperficiePotencialUvaVinos.FindAsync(id);
            if (tipoSuperficiePotencialUvaVino == null)
            {
                return NotFound();
            }

            _context.TipoSuperficiePotencialUvaVinos.Remove(tipoSuperficiePotencialUvaVino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoSuperficiePotencialUvaVinoExists(int id)
        {
            return (_context.TipoSuperficiePotencialUvaVinos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
