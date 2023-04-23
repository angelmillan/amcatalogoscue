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
    public class SistemasCultivoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public SistemasCultivoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/SistemaCultivoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SistemaCultivo>>> GetSistemaCultivos()
        {
          if (_context.SistemaCultivos == null)
          {
              return NotFound();
          }
            return await _context.SistemaCultivos.ToListAsync();
        }

        // GET: api/SistemaCultivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SistemaCultivo>> GetSistemaCultivo(int id)
        {
          if (_context.SistemaCultivos == null)
          {
              return NotFound();
          }
            var sistemaCultivo = await _context.SistemaCultivos.FindAsync(id);

            if (sistemaCultivo == null)
            {
                return NotFound();
            }

            return sistemaCultivo;
        }

        // PUT: api/SistemaCultivoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemaCultivo(int id, SistemaCultivo sistemaCultivo)
        {
            if (id != sistemaCultivo.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(sistemaCultivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaCultivoExists(id))
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

        // POST: api/SistemaCultivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SistemaCultivo>> PostSistemaCultivo(SistemaCultivo sistemaCultivo)
        {
          if (_context.SistemaCultivos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.SistemaCultivos'  is null.");
          }
            _context.SistemaCultivos.Add(sistemaCultivo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SistemaCultivoExists(sistemaCultivo.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSistemaCultivo", new { id = sistemaCultivo.CodigoSiex }, sistemaCultivo);
        }

        // DELETE: api/SistemaCultivoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemaCultivo(int id)
        {
            if (_context.SistemaCultivos == null)
            {
                return NotFound();
            }
            var sistemaCultivo = await _context.SistemaCultivos.FindAsync(id);
            if (sistemaCultivo == null)
            {
                return NotFound();
            }

            _context.SistemaCultivos.Remove(sistemaCultivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SistemaCultivoExists(int id)
        {
            return (_context.SistemaCultivos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
