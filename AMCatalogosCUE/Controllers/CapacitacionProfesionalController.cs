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
    public class CapacitacionProfesionalController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public CapacitacionProfesionalController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/CapacitacionProfesionals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacitacionProfesional>>> GetCapacitacionProfesionals()
        {
          if (_context.CapacitacionProfesionals == null)
          {
              return NotFound();
          }
            return await _context.CapacitacionProfesionals.ToListAsync();
        }

        // GET: api/CapacitacionProfesionals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacitacionProfesional>> GetCapacitacionProfesional(int id)
        {
          if (_context.CapacitacionProfesionals == null)
          {
              return NotFound();
          }
            var capacitacionProfesional = await _context.CapacitacionProfesionals.FindAsync(id);

            if (capacitacionProfesional == null)
            {
                return NotFound();
            }

            return capacitacionProfesional;
        }

        // PUT: api/CapacitacionProfesionals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacitacionProfesional(int id, CapacitacionProfesional capacitacionProfesional)
        {
            if (id != capacitacionProfesional.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(capacitacionProfesional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacitacionProfesionalExists(id))
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

        // POST: api/CapacitacionProfesionals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CapacitacionProfesional>> PostCapacitacionProfesional(CapacitacionProfesional capacitacionProfesional)
        {
          if (_context.CapacitacionProfesionals == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.CapacitacionProfesionals'  is null.");
          }
            _context.CapacitacionProfesionals.Add(capacitacionProfesional);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CapacitacionProfesionalExists(capacitacionProfesional.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCapacitacionProfesional", new { id = capacitacionProfesional.CodigoSiex }, capacitacionProfesional);
        }

        // DELETE: api/CapacitacionProfesionals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapacitacionProfesional(int id)
        {
            if (_context.CapacitacionProfesionals == null)
            {
                return NotFound();
            }
            var capacitacionProfesional = await _context.CapacitacionProfesionals.FindAsync(id);
            if (capacitacionProfesional == null)
            {
                return NotFound();
            }

            _context.CapacitacionProfesionals.Remove(capacitacionProfesional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CapacitacionProfesionalExists(int id)
        {
            return (_context.CapacitacionProfesionals?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
