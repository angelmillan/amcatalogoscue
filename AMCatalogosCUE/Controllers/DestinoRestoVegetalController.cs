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
    public class DestinoRestoVegetalController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public DestinoRestoVegetalController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/DestinoRestoVegetals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinoRestoVegetal>>> GetDestinoRestoVegetals()
        {
          if (_context.DestinoRestoVegetals == null)
          {
              return NotFound();
          }
            return await _context.DestinoRestoVegetals.ToListAsync();
        }

        // GET: api/DestinoRestoVegetals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinoRestoVegetal>> GetDestinoRestoVegetal(int id)
        {
          if (_context.DestinoRestoVegetals == null)
          {
              return NotFound();
          }
            var destinoRestoVegetal = await _context.DestinoRestoVegetals.FindAsync(id);

            if (destinoRestoVegetal == null)
            {
                return NotFound();
            }

            return destinoRestoVegetal;
        }

        // PUT: api/DestinoRestoVegetals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinoRestoVegetal(int id, DestinoRestoVegetal destinoRestoVegetal)
        {
            if (id != destinoRestoVegetal.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(destinoRestoVegetal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoRestoVegetalExists(id))
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

        // POST: api/DestinoRestoVegetals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DestinoRestoVegetal>> PostDestinoRestoVegetal(DestinoRestoVegetal destinoRestoVegetal)
        {
          if (_context.DestinoRestoVegetals == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.DestinoRestoVegetals'  is null.");
          }
            _context.DestinoRestoVegetals.Add(destinoRestoVegetal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DestinoRestoVegetalExists(destinoRestoVegetal.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDestinoRestoVegetal", new { id = destinoRestoVegetal.CodigoSiex }, destinoRestoVegetal);
        }

        // DELETE: api/DestinoRestoVegetals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinoRestoVegetal(int id)
        {
            if (_context.DestinoRestoVegetals == null)
            {
                return NotFound();
            }
            var destinoRestoVegetal = await _context.DestinoRestoVegetals.FindAsync(id);
            if (destinoRestoVegetal == null)
            {
                return NotFound();
            }

            _context.DestinoRestoVegetals.Remove(destinoRestoVegetal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoRestoVegetalExists(int id)
        {
            return (_context.DestinoRestoVegetals?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
