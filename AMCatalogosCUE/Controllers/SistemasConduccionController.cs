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
    public class SistemasConduccionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public SistemasConduccionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/SistemaConduccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SistemaConduccion>>> GetSistemaConduccions()
        {
          if (_context.SistemaConduccions == null)
          {
              return NotFound();
          }
            return await _context.SistemaConduccions.ToListAsync();
        }

        // GET: api/SistemaConduccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SistemaConduccion>> GetSistemaConduccion(int id)
        {
          if (_context.SistemaConduccions == null)
          {
              return NotFound();
          }
            var sistemaConduccion = await _context.SistemaConduccions.FindAsync(id);

            if (sistemaConduccion == null)
            {
                return NotFound();
            }

            return sistemaConduccion;
        }

        // PUT: api/SistemaConduccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemaConduccion(int id, SistemaConduccion sistemaConduccion)
        {
            if (id != sistemaConduccion.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(sistemaConduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaConduccionExists(id))
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

        // POST: api/SistemaConduccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SistemaConduccion>> PostSistemaConduccion(SistemaConduccion sistemaConduccion)
        {
          if (_context.SistemaConduccions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.SistemaConduccions'  is null.");
          }
            _context.SistemaConduccions.Add(sistemaConduccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SistemaConduccionExists(sistemaConduccion.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSistemaConduccion", new { id = sistemaConduccion.CodigoSiex }, sistemaConduccion);
        }

        // DELETE: api/SistemaConduccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemaConduccion(int id)
        {
            if (_context.SistemaConduccions == null)
            {
                return NotFound();
            }
            var sistemaConduccion = await _context.SistemaConduccions.FindAsync(id);
            if (sistemaConduccion == null)
            {
                return NotFound();
            }

            _context.SistemaConduccions.Remove(sistemaConduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SistemaConduccionExists(int id)
        {
            return (_context.SistemaConduccions?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
