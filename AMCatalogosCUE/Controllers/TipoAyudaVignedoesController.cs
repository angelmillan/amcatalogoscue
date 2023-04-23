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
    public class TipoAyudaVignedoesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TipoAyudaVignedoesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoAyudaVignedoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAyudaVignedo>>> GetTipoAyudaVignedos()
        {
          if (_context.TipoAyudaVignedos == null)
          {
              return NotFound();
          }
            return await _context.TipoAyudaVignedos.ToListAsync();
        }

        // GET: api/TipoAyudaVignedoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAyudaVignedo>> GetTipoAyudaVignedo(int id)
        {
          if (_context.TipoAyudaVignedos == null)
          {
              return NotFound();
          }
            var tipoAyudaVignedo = await _context.TipoAyudaVignedos.FindAsync(id);

            if (tipoAyudaVignedo == null)
            {
                return NotFound();
            }

            return tipoAyudaVignedo;
        }

        // PUT: api/TipoAyudaVignedoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAyudaVignedo(int id, TipoAyudaVignedo tipoAyudaVignedo)
        {
            if (id != tipoAyudaVignedo.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoAyudaVignedo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAyudaVignedoExists(id))
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

        // POST: api/TipoAyudaVignedoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoAyudaVignedo>> PostTipoAyudaVignedo(TipoAyudaVignedo tipoAyudaVignedo)
        {
          if (_context.TipoAyudaVignedos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoAyudaVignedos'  is null.");
          }
            _context.TipoAyudaVignedos.Add(tipoAyudaVignedo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoAyudaVignedoExists(tipoAyudaVignedo.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoAyudaVignedo", new { id = tipoAyudaVignedo.CodigoSiex }, tipoAyudaVignedo);
        }

        // DELETE: api/TipoAyudaVignedoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAyudaVignedo(int id)
        {
            if (_context.TipoAyudaVignedos == null)
            {
                return NotFound();
            }
            var tipoAyudaVignedo = await _context.TipoAyudaVignedos.FindAsync(id);
            if (tipoAyudaVignedo == null)
            {
                return NotFound();
            }

            _context.TipoAyudaVignedos.Remove(tipoAyudaVignedo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoAyudaVignedoExists(int id)
        {
            return (_context.TipoAyudaVignedos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
