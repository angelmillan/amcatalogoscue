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
    public class UnidadesMedidaController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public UnidadesMedidaController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedidums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadesMedidum>>> GetUnidadesMedida()
        {
          if (_context.UnidadesMedida == null)
          {
              return NotFound();
          }
            return await _context.UnidadesMedida.ToListAsync();
        }

        // GET: api/UnidadesMedidums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadesMedidum>> GetUnidadesMedidum(int id)
        {
          if (_context.UnidadesMedida == null)
          {
              return NotFound();
          }
            var unidadesMedidum = await _context.UnidadesMedida.FindAsync(id);

            if (unidadesMedidum == null)
            {
                return NotFound();
            }

            return unidadesMedidum;
        }

        // PUT: api/UnidadesMedidums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadesMedidum(int id, UnidadesMedidum unidadesMedidum)
        {
            if (id != unidadesMedidum.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(unidadesMedidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadesMedidumExists(id))
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

        // POST: api/UnidadesMedidums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadesMedidum>> PostUnidadesMedidum(UnidadesMedidum unidadesMedidum)
        {
          if (_context.UnidadesMedida == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.UnidadesMedida'  is null.");
          }
            _context.UnidadesMedida.Add(unidadesMedidum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnidadesMedidumExists(unidadesMedidum.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnidadesMedidum", new { id = unidadesMedidum.CodigoSiex }, unidadesMedidum);
        }

        // DELETE: api/UnidadesMedidums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadesMedidum(int id)
        {
            if (_context.UnidadesMedida == null)
            {
                return NotFound();
            }
            var unidadesMedidum = await _context.UnidadesMedida.FindAsync(id);
            if (unidadesMedidum == null)
            {
                return NotFound();
            }

            _context.UnidadesMedida.Remove(unidadesMedidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadesMedidumExists(int id)
        {
            return (_context.UnidadesMedida?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
