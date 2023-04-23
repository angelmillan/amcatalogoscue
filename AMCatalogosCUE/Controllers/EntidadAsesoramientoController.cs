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
    public class EntidadAsesoramientoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public EntidadAsesoramientoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/EntidadAsesoramientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntidadAsesoramiento>>> GetEntidadAsesoramientos()
        {
          if (_context.EntidadAsesoramientos == null)
          {
              return NotFound();
          }
            return await _context.EntidadAsesoramientos.ToListAsync();
        }

        // GET: api/EntidadAsesoramientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntidadAsesoramiento>> GetEntidadAsesoramiento(int id)
        {
          if (_context.EntidadAsesoramientos == null)
          {
              return NotFound();
          }
            var entidadAsesoramiento = await _context.EntidadAsesoramientos.FindAsync(id);

            if (entidadAsesoramiento == null)
            {
                return NotFound();
            }

            return entidadAsesoramiento;
        }

        // PUT: api/EntidadAsesoramientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidadAsesoramiento(int id, EntidadAsesoramiento entidadAsesoramiento)
        {
            if (id != entidadAsesoramiento.CodigoAsociacion)
            {
                return BadRequest();
            }

            _context.Entry(entidadAsesoramiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadAsesoramientoExists(id))
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

        // POST: api/EntidadAsesoramientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntidadAsesoramiento>> PostEntidadAsesoramiento(EntidadAsesoramiento entidadAsesoramiento)
        {
          if (_context.EntidadAsesoramientos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.EntidadAsesoramientos'  is null.");
          }
            _context.EntidadAsesoramientos.Add(entidadAsesoramiento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntidadAsesoramientoExists(entidadAsesoramiento.CodigoAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntidadAsesoramiento", new { id = entidadAsesoramiento.CodigoAsociacion }, entidadAsesoramiento);
        }

        // DELETE: api/EntidadAsesoramientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidadAsesoramiento(int id)
        {
            if (_context.EntidadAsesoramientos == null)
            {
                return NotFound();
            }
            var entidadAsesoramiento = await _context.EntidadAsesoramientos.FindAsync(id);
            if (entidadAsesoramiento == null)
            {
                return NotFound();
            }

            _context.EntidadAsesoramientos.Remove(entidadAsesoramiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntidadAsesoramientoExists(int id)
        {
            return (_context.EntidadAsesoramientos?.Any(e => e.CodigoAsociacion == id)).GetValueOrDefault();
        }
    }
}
