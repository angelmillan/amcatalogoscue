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
    public class DesmotadorasController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public DesmotadorasController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/Desmotadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desmotadora>>> GetDesmotadoras()
        {
          if (_context.Desmotadoras == null)
          {
              return NotFound();
          }
            return await _context.Desmotadoras.ToListAsync();
        }

        // GET: api/Desmotadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desmotadora>> GetDesmotadora(int id)
        {
          if (_context.Desmotadoras == null)
          {
              return NotFound();
          }
            var desmotadora = await _context.Desmotadoras.FindAsync(id);

            if (desmotadora == null)
            {
                return NotFound();
            }

            return desmotadora;
        }

        // PUT: api/Desmotadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesmotadora(int id, Desmotadora desmotadora)
        {
            if (id != desmotadora.CodigoAsociacion)
            {
                return BadRequest();
            }

            _context.Entry(desmotadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesmotadoraExists(id))
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

        // POST: api/Desmotadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Desmotadora>> PostDesmotadora(Desmotadora desmotadora)
        {
          if (_context.Desmotadoras == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.Desmotadoras'  is null.");
          }
            _context.Desmotadoras.Add(desmotadora);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DesmotadoraExists(desmotadora.CodigoAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDesmotadora", new { id = desmotadora.CodigoAsociacion }, desmotadora);
        }

        // DELETE: api/Desmotadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesmotadora(int id)
        {
            if (_context.Desmotadoras == null)
            {
                return NotFound();
            }
            var desmotadora = await _context.Desmotadoras.FindAsync(id);
            if (desmotadora == null)
            {
                return NotFound();
            }

            _context.Desmotadoras.Remove(desmotadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesmotadoraExists(int id)
        {
            return (_context.Desmotadoras?.Any(e => e.CodigoAsociacion == id)).GetValueOrDefault();
        }
    }
}
