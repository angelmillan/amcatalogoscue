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
    public class EficaciaTratamientoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public EficaciaTratamientoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/EficaciaTratamientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EficaciaTratamiento>>> GetEficaciaTratamientos()
        {
          if (_context.EficaciaTratamientos == null)
          {
              return NotFound();
          }
            return await _context.EficaciaTratamientos.ToListAsync();
        }

        // GET: api/EficaciaTratamientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EficaciaTratamiento>> GetEficaciaTratamiento(int id)
        {
          if (_context.EficaciaTratamientos == null)
          {
              return NotFound();
          }
            var eficaciaTratamiento = await _context.EficaciaTratamientos.FindAsync(id);

            if (eficaciaTratamiento == null)
            {
                return NotFound();
            }

            return eficaciaTratamiento;
        }

        // PUT: api/EficaciaTratamientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEficaciaTratamiento(int id, EficaciaTratamiento eficaciaTratamiento)
        {
            if (id != eficaciaTratamiento.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(eficaciaTratamiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EficaciaTratamientoExists(id))
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

        // POST: api/EficaciaTratamientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EficaciaTratamiento>> PostEficaciaTratamiento(EficaciaTratamiento eficaciaTratamiento)
        {
          if (_context.EficaciaTratamientos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.EficaciaTratamientos'  is null.");
          }
            _context.EficaciaTratamientos.Add(eficaciaTratamiento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EficaciaTratamientoExists(eficaciaTratamiento.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEficaciaTratamiento", new { id = eficaciaTratamiento.CodigoSiex }, eficaciaTratamiento);
        }

        // DELETE: api/EficaciaTratamientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEficaciaTratamiento(int id)
        {
            if (_context.EficaciaTratamientos == null)
            {
                return NotFound();
            }
            var eficaciaTratamiento = await _context.EficaciaTratamientos.FindAsync(id);
            if (eficaciaTratamiento == null)
            {
                return NotFound();
            }

            _context.EficaciaTratamientos.Remove(eficaciaTratamiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EficaciaTratamientoExists(int id)
        {
            return (_context.EficaciaTratamientos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
