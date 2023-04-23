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
    public class ReguladoresCrecimientoyOtrosController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ReguladoresCrecimientoyOtrosController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ReguladoresCrecimientoyOtroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReguladoresCrecimientoyOtro>>> GetReguladoresCrecimientoyOtros()
        {
          if (_context.ReguladoresCrecimientoyOtros == null)
          {
              return NotFound();
          }
            return await _context.ReguladoresCrecimientoyOtros.ToListAsync();
        }

        // GET: api/ReguladoresCrecimientoyOtroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReguladoresCrecimientoyOtro>> GetReguladoresCrecimientoyOtro(string id)
        {
          if (_context.ReguladoresCrecimientoyOtros == null)
          {
              return NotFound();
          }
            var reguladoresCrecimientoyOtro = await _context.ReguladoresCrecimientoyOtros.FindAsync(id);

            if (reguladoresCrecimientoyOtro == null)
            {
                return NotFound();
            }

            return reguladoresCrecimientoyOtro;
        }

        // PUT: api/ReguladoresCrecimientoyOtroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReguladoresCrecimientoyOtro(string id, ReguladoresCrecimientoyOtro reguladoresCrecimientoyOtro)
        {
            if (id != reguladoresCrecimientoyOtro.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(reguladoresCrecimientoyOtro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReguladoresCrecimientoyOtroExists(id))
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

        // POST: api/ReguladoresCrecimientoyOtroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReguladoresCrecimientoyOtro>> PostReguladoresCrecimientoyOtro(ReguladoresCrecimientoyOtro reguladoresCrecimientoyOtro)
        {
          if (_context.ReguladoresCrecimientoyOtros == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ReguladoresCrecimientoyOtros'  is null.");
          }
            _context.ReguladoresCrecimientoyOtros.Add(reguladoresCrecimientoyOtro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReguladoresCrecimientoyOtroExists(reguladoresCrecimientoyOtro.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReguladoresCrecimientoyOtro", new { id = reguladoresCrecimientoyOtro.Codigo }, reguladoresCrecimientoyOtro);
        }

        // DELETE: api/ReguladoresCrecimientoyOtroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReguladoresCrecimientoyOtro(string id)
        {
            if (_context.ReguladoresCrecimientoyOtros == null)
            {
                return NotFound();
            }
            var reguladoresCrecimientoyOtro = await _context.ReguladoresCrecimientoyOtros.FindAsync(id);
            if (reguladoresCrecimientoyOtro == null)
            {
                return NotFound();
            }

            _context.ReguladoresCrecimientoyOtros.Remove(reguladoresCrecimientoyOtro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReguladoresCrecimientoyOtroExists(string id)
        {
            return (_context.ReguladoresCrecimientoyOtros?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
