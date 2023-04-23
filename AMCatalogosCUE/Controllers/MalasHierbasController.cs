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
    public class MalasHierbasController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public MalasHierbasController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/MalasHierbas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MalasHierba>>> GetMalasHierbas()
        {
          if (_context.MalasHierbas == null)
          {
              return NotFound();
          }
            return await _context.MalasHierbas.ToListAsync();
        }

        // GET: api/MalasHierbas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MalasHierba>> GetMalasHierba(string id)
        {
          if (_context.MalasHierbas == null)
          {
              return NotFound();
          }
            var malasHierba = await _context.MalasHierbas.FindAsync(id);

            if (malasHierba == null)
            {
                return NotFound();
            }

            return malasHierba;
        }

        // PUT: api/MalasHierbas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMalasHierba(string id, MalasHierba malasHierba)
        {
            if (id != malasHierba.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(malasHierba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MalasHierbaExists(id))
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

        // POST: api/MalasHierbas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MalasHierba>> PostMalasHierba(MalasHierba malasHierba)
        {
          if (_context.MalasHierbas == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.MalasHierbas'  is null.");
          }
            _context.MalasHierbas.Add(malasHierba);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MalasHierbaExists(malasHierba.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMalasHierba", new { id = malasHierba.Codigo }, malasHierba);
        }

        // DELETE: api/MalasHierbas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMalasHierba(string id)
        {
            if (_context.MalasHierbas == null)
            {
                return NotFound();
            }
            var malasHierba = await _context.MalasHierbas.FindAsync(id);
            if (malasHierba == null)
            {
                return NotFound();
            }

            _context.MalasHierbas.Remove(malasHierba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MalasHierbaExists(string id)
        {
            return (_context.MalasHierbas?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
