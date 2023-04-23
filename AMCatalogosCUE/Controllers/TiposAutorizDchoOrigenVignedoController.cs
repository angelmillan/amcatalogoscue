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
    public class TiposAutorizDchoOrigenVignedoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposAutorizDchoOrigenVignedoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoaAutorizDchoOrigenVignedoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoaAutorizDchoOrigenVignedo>>> GetTipoaAutorizDchoOrigenVignedos()
        {
          if (_context.TipoaAutorizDchoOrigenVignedos == null)
          {
              return NotFound();
          }
            return await _context.TipoaAutorizDchoOrigenVignedos.ToListAsync();
        }

        // GET: api/TipoaAutorizDchoOrigenVignedoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoaAutorizDchoOrigenVignedo>> GetTipoaAutorizDchoOrigenVignedo(int id)
        {
          if (_context.TipoaAutorizDchoOrigenVignedos == null)
          {
              return NotFound();
          }
            var tipoaAutorizDchoOrigenVignedo = await _context.TipoaAutorizDchoOrigenVignedos.FindAsync(id);

            if (tipoaAutorizDchoOrigenVignedo == null)
            {
                return NotFound();
            }

            return tipoaAutorizDchoOrigenVignedo;
        }

        // PUT: api/TipoaAutorizDchoOrigenVignedoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoaAutorizDchoOrigenVignedo(int id, TipoaAutorizDchoOrigenVignedo tipoaAutorizDchoOrigenVignedo)
        {
            if (id != tipoaAutorizDchoOrigenVignedo.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoaAutorizDchoOrigenVignedo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoaAutorizDchoOrigenVignedoExists(id))
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

        // POST: api/TipoaAutorizDchoOrigenVignedoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoaAutorizDchoOrigenVignedo>> PostTipoaAutorizDchoOrigenVignedo(TipoaAutorizDchoOrigenVignedo tipoaAutorizDchoOrigenVignedo)
        {
          if (_context.TipoaAutorizDchoOrigenVignedos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoaAutorizDchoOrigenVignedos'  is null.");
          }
            _context.TipoaAutorizDchoOrigenVignedos.Add(tipoaAutorizDchoOrigenVignedo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoaAutorizDchoOrigenVignedoExists(tipoaAutorizDchoOrigenVignedo.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoaAutorizDchoOrigenVignedo", new { id = tipoaAutorizDchoOrigenVignedo.CodigoSiex }, tipoaAutorizDchoOrigenVignedo);
        }

        // DELETE: api/TipoaAutorizDchoOrigenVignedoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoaAutorizDchoOrigenVignedo(int id)
        {
            if (_context.TipoaAutorizDchoOrigenVignedos == null)
            {
                return NotFound();
            }
            var tipoaAutorizDchoOrigenVignedo = await _context.TipoaAutorizDchoOrigenVignedos.FindAsync(id);
            if (tipoaAutorizDchoOrigenVignedo == null)
            {
                return NotFound();
            }

            _context.TipoaAutorizDchoOrigenVignedos.Remove(tipoaAutorizDchoOrigenVignedo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoaAutorizDchoOrigenVignedoExists(int id)
        {
            return (_context.TipoaAutorizDchoOrigenVignedos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
