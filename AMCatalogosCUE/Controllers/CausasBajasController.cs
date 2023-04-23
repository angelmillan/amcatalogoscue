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
    public class CausasBajasController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public CausasBajasController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/CausasBajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CausasBaja>>> GetCausasBajas()
        {
          if (_context.CausasBajas == null)
          {
              return NotFound();
          }
            return await _context.CausasBajas.ToListAsync();
        }

        // GET: api/CausasBajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CausasBaja>> GetCausasBaja(int id)
        {
          if (_context.CausasBajas == null)
          {
              return NotFound();
          }
            var causasBaja = await _context.CausasBajas.FindAsync(id);

            if (causasBaja == null)
            {
                return NotFound();
            }

            return causasBaja;
        }

        // PUT: api/CausasBajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCausasBaja(int id, CausasBaja causasBaja)
        {
            if (id != causasBaja.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(causasBaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CausasBajaExists(id))
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

        // POST: api/CausasBajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CausasBaja>> PostCausasBaja(CausasBaja causasBaja)
        {
          if (_context.CausasBajas == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.CausasBajas'  is null.");
          }
            _context.CausasBajas.Add(causasBaja);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CausasBajaExists(causasBaja.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCausasBaja", new { id = causasBaja.CodigoSiex }, causasBaja);
        }

        // DELETE: api/CausasBajas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCausasBaja(int id)
        {
            if (_context.CausasBajas == null)
            {
                return NotFound();
            }
            var causasBaja = await _context.CausasBajas.FindAsync(id);
            if (causasBaja == null)
            {
                return NotFound();
            }

            _context.CausasBajas.Remove(causasBaja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CausasBajaExists(int id)
        {
            return (_context.CausasBajas?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
