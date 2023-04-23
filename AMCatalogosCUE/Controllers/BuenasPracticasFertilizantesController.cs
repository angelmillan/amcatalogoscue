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
    public class BuenasPracticasFertilizantesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public BuenasPracticasFertilizantesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/BuenasPracticasFertilizantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuenasPracticasFertilizante>>> GetBuenasPracticasFertilizantes()
        {
          if (_context.BuenasPracticasFertilizantes == null)
          {
              return NotFound();
          }
            return await _context.BuenasPracticasFertilizantes.ToListAsync();
        }

        // GET: api/BuenasPracticasFertilizantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuenasPracticasFertilizante>> GetBuenasPracticasFertilizante(int id)
        {
          if (_context.BuenasPracticasFertilizantes == null)
          {
              return NotFound();
          }
            var buenasPracticasFertilizante = await _context.BuenasPracticasFertilizantes.FindAsync(id);

            if (buenasPracticasFertilizante == null)
            {
                return NotFound();
            }

            return buenasPracticasFertilizante;
        }

        // PUT: api/BuenasPracticasFertilizantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuenasPracticasFertilizante(int id, BuenasPracticasFertilizante buenasPracticasFertilizante)
        {
            if (id != buenasPracticasFertilizante.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(buenasPracticasFertilizante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuenasPracticasFertilizanteExists(id))
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

        // POST: api/BuenasPracticasFertilizantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuenasPracticasFertilizante>> PostBuenasPracticasFertilizante(BuenasPracticasFertilizante buenasPracticasFertilizante)
        {
          if (_context.BuenasPracticasFertilizantes == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.BuenasPracticasFertilizantes'  is null.");
          }
            _context.BuenasPracticasFertilizantes.Add(buenasPracticasFertilizante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuenasPracticasFertilizanteExists(buenasPracticasFertilizante.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBuenasPracticasFertilizante", new { id = buenasPracticasFertilizante.CodigoSiex }, buenasPracticasFertilizante);
        }

        // DELETE: api/BuenasPracticasFertilizantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuenasPracticasFertilizante(int id)
        {
            if (_context.BuenasPracticasFertilizantes == null)
            {
                return NotFound();
            }
            var buenasPracticasFertilizante = await _context.BuenasPracticasFertilizantes.FindAsync(id);
            if (buenasPracticasFertilizante == null)
            {
                return NotFound();
            }

            _context.BuenasPracticasFertilizantes.Remove(buenasPracticasFertilizante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuenasPracticasFertilizanteExists(int id)
        {
            return (_context.BuenasPracticasFertilizantes?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
