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
    public class OpfhController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public OpfhController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/Opfhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opfh>>> GetOpfhs()
        {
          if (_context.Opfhs == null)
          {
              return NotFound();
          }
            return await _context.Opfhs.ToListAsync();
        }

        // GET: api/Opfhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Opfh>> GetOpfh(string id)
        {
          if (_context.Opfhs == null)
          {
              return NotFound();
          }
            var opfh = await _context.Opfhs.FindAsync(id);

            if (opfh == null)
            {
                return NotFound();
            }

            return opfh;
        }

        // PUT: api/Opfhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpfh(string id, Opfh opfh)
        {
            if (id != opfh.CodigoAsociacion)
            {
                return BadRequest();
            }

            _context.Entry(opfh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpfhExists(id))
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

        // POST: api/Opfhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Opfh>> PostOpfh(Opfh opfh)
        {
          if (_context.Opfhs == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.Opfhs'  is null.");
          }
            _context.Opfhs.Add(opfh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OpfhExists(opfh.CodigoAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOpfh", new { id = opfh.CodigoAsociacion }, opfh);
        }

        // DELETE: api/Opfhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpfh(string id)
        {
            if (_context.Opfhs == null)
            {
                return NotFound();
            }
            var opfh = await _context.Opfhs.FindAsync(id);
            if (opfh == null)
            {
                return NotFound();
            }

            _context.Opfhs.Remove(opfh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpfhExists(string id)
        {
            return (_context.Opfhs?.Any(e => e.CodigoAsociacion == id)).GetValueOrDefault();
        }
    }
}
