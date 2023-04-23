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
    public class BuenasPracticasRiegoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public BuenasPracticasRiegoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/BuenasPracticasRiegoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuenasPracticasRiego>>> GetBuenasPracticasRiegos()
        {
          if (_context.BuenasPracticasRiegos == null)
          {
              return NotFound();
          }
            return await _context.BuenasPracticasRiegos.ToListAsync();
        }

        // GET: api/BuenasPracticasRiegoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuenasPracticasRiego>> GetBuenasPracticasRiego(int id)
        {
          if (_context.BuenasPracticasRiegos == null)
          {
              return NotFound();
          }
            var buenasPracticasRiego = await _context.BuenasPracticasRiegos.FindAsync(id);

            if (buenasPracticasRiego == null)
            {
                return NotFound();
            }

            return buenasPracticasRiego;
        }

        // PUT: api/BuenasPracticasRiegoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuenasPracticasRiego(int id, BuenasPracticasRiego buenasPracticasRiego)
        {
            if (id != buenasPracticasRiego.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(buenasPracticasRiego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuenasPracticasRiegoExists(id))
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

        // POST: api/BuenasPracticasRiegoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuenasPracticasRiego>> PostBuenasPracticasRiego(BuenasPracticasRiego buenasPracticasRiego)
        {
          if (_context.BuenasPracticasRiegos == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.BuenasPracticasRiegos'  is null.");
          }
            _context.BuenasPracticasRiegos.Add(buenasPracticasRiego);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuenasPracticasRiegoExists(buenasPracticasRiego.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuenasPracticasRiego", new { id = buenasPracticasRiego.CodigoSiex }, buenasPracticasRiego);
        }

        // DELETE: api/BuenasPracticasRiegoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuenasPracticasRiego(int id)
        {
            if (_context.BuenasPracticasRiegos == null)
            {
                return NotFound();
            }
            var buenasPracticasRiego = await _context.BuenasPracticasRiegos.FindAsync(id);
            if (buenasPracticasRiego == null)
            {
                return NotFound();
            }

            _context.BuenasPracticasRiegos.Remove(buenasPracticasRiego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuenasPracticasRiegoExists(int id)
        {
            return (_context.BuenasPracticasRiegos?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
