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
    public class PortainjertosController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public PortainjertosController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/Portainjertoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portainjerto>>> GetPortainjertos()
        {
          if (_context.Portainjertos == null)
          {
              return NotFound();
          }
            return await _context.Portainjertos.ToListAsync();
        }

        // GET: api/Portainjertoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portainjerto>> GetPortainjerto(int id)
        {
          if (_context.Portainjertos == null)
          {
              return NotFound();
          }
            var portainjerto = await _context.Portainjertos.FindAsync(id);

            if (portainjerto == null)
            {
                return NotFound();
            }

            return portainjerto;
        }

        // PUT: api/Portainjertoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortainjerto(int id, Portainjerto portainjerto)
        {
            if (id != portainjerto.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(portainjerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortainjertoExists(id))
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

        // POST: api/Portainjertoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Portainjerto>> PostPortainjerto(Portainjerto portainjerto)
        {
          if (_context.Portainjertos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.Portainjertos'  is null.");
          }
            _context.Portainjertos.Add(portainjerto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PortainjertoExists(portainjerto.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPortainjerto", new { id = portainjerto.CodigoSiex }, portainjerto);
        }

        // DELETE: api/Portainjertoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortainjerto(int id)
        {
            if (_context.Portainjertos == null)
            {
                return NotFound();
            }
            var portainjerto = await _context.Portainjertos.FindAsync(id);
            if (portainjerto == null)
            {
                return NotFound();
            }

            _context.Portainjertos.Remove(portainjerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortainjertoExists(int id)
        {
            return (_context.Portainjertos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
