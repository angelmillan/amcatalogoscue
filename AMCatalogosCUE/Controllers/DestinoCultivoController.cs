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
    public class DestinoCultivoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public DestinoCultivoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/DestinoCultivoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinoCultivo>>> GetDestinoCultivos()
        {
          if (_context.DestinoCultivos == null)
          {
              return NotFound();
          }
            return await _context.DestinoCultivos.ToListAsync();
        }

        // GET: api/DestinoCultivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinoCultivo>> GetDestinoCultivo(int id)
        {
          if (_context.DestinoCultivos == null)
          {
              return NotFound();
          }
            var destinoCultivo = await _context.DestinoCultivos.FindAsync(id);

            if (destinoCultivo == null)
            {
                return NotFound();
            }

            return destinoCultivo;
        }

        // PUT: api/DestinoCultivoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinoCultivo(int id, DestinoCultivo destinoCultivo)
        {
            if (id != destinoCultivo.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(destinoCultivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoCultivoExists(id))
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

        // POST: api/DestinoCultivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DestinoCultivo>> PostDestinoCultivo(DestinoCultivo destinoCultivo)
        {
          if (_context.DestinoCultivos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.DestinoCultivos'  is null.");
          }
            _context.DestinoCultivos.Add(destinoCultivo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DestinoCultivoExists(destinoCultivo.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDestinoCultivo", new { id = destinoCultivo.CodigoSiex }, destinoCultivo);
        }

        // DELETE: api/DestinoCultivoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinoCultivo(int id)
        {
            if (_context.DestinoCultivos == null)
            {
                return NotFound();
            }
            var destinoCultivo = await _context.DestinoCultivos.FindAsync(id);
            if (destinoCultivo == null)
            {
                return NotFound();
            }

            _context.DestinoCultivos.Remove(destinoCultivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoCultivoExists(int id)
        {
            return (_context.DestinoCultivos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
