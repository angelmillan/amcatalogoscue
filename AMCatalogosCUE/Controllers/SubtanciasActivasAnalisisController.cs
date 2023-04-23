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
    public class SubtanciasActivasAnalisisController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public SubtanciasActivasAnalisisController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/SubtanciasActivasAnalisis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubtanciasActivasAnalisi>>> GetSubtanciasActivasAnalises()
        {
          if (_context.SubtanciasActivasAnalises == null)
          {
              return NotFound();
          }
            return await _context.SubtanciasActivasAnalises.ToListAsync();
        }

        // GET: api/SubtanciasActivasAnalisis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubtanciasActivasAnalisi>> GetSubtanciasActivasAnalisi(int id)
        {
          if (_context.SubtanciasActivasAnalises == null)
          {
              return NotFound();
          }
            var subtanciasActivasAnalisi = await _context.SubtanciasActivasAnalises.FindAsync(id);

            if (subtanciasActivasAnalisi == null)
            {
                return NotFound();
            }

            return subtanciasActivasAnalisi;
        }

        // PUT: api/SubtanciasActivasAnalisis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubtanciasActivasAnalisi(int id, SubtanciasActivasAnalisi subtanciasActivasAnalisi)
        {
            if (id != subtanciasActivasAnalisi.ActiveSubstanceId)
            {
                return BadRequest();
            }

            _context.Entry(subtanciasActivasAnalisi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubtanciasActivasAnalisiExists(id))
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

        // POST: api/SubtanciasActivasAnalisis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubtanciasActivasAnalisi>> PostSubtanciasActivasAnalisi(SubtanciasActivasAnalisi subtanciasActivasAnalisi)
        {
          if (_context.SubtanciasActivasAnalises == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.SubtanciasActivasAnalises'  is null.");
          }
            _context.SubtanciasActivasAnalises.Add(subtanciasActivasAnalisi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubtanciasActivasAnalisiExists(subtanciasActivasAnalisi.ActiveSubstanceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubtanciasActivasAnalisi", new { id = subtanciasActivasAnalisi.ActiveSubstanceId }, subtanciasActivasAnalisi);
        }

        // DELETE: api/SubtanciasActivasAnalisis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubtanciasActivasAnalisi(int id)
        {
            if (_context.SubtanciasActivasAnalises == null)
            {
                return NotFound();
            }
            var subtanciasActivasAnalisi = await _context.SubtanciasActivasAnalises.FindAsync(id);
            if (subtanciasActivasAnalisi == null)
            {
                return NotFound();
            }

            _context.SubtanciasActivasAnalises.Remove(subtanciasActivasAnalisi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubtanciasActivasAnalisiExists(int id)
        {
            return (_context.SubtanciasActivasAnalises?.Any(e => e.ActiveSubstanceId == id)).GetValueOrDefault();
        }
    }
}
