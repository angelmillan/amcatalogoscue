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
    public class MedidaPreventivaCulturalController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public MedidaPreventivaCulturalController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/MedidaPreventivaCulturals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedidaPreventivaCultural>>> GetMedidaPreventivaCulturals()
        {
          if (_context.MedidaPreventivaCulturals == null)
          {
              return NotFound();
          }
            return await _context.MedidaPreventivaCulturals.ToListAsync();
        }

        // GET: api/MedidaPreventivaCulturals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedidaPreventivaCultural>> GetMedidaPreventivaCultural(int id)
        {
          if (_context.MedidaPreventivaCulturals == null)
          {
              return NotFound();
          }
            var medidaPreventivaCultural = await _context.MedidaPreventivaCulturals.FindAsync(id);

            if (medidaPreventivaCultural == null)
            {
                return NotFound();
            }

            return medidaPreventivaCultural;
        }

        // PUT: api/MedidaPreventivaCulturals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidaPreventivaCultural(int id, MedidaPreventivaCultural medidaPreventivaCultural)
        {
            if (id != medidaPreventivaCultural.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(medidaPreventivaCultural).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidaPreventivaCulturalExists(id))
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

        // POST: api/MedidaPreventivaCulturals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedidaPreventivaCultural>> PostMedidaPreventivaCultural(MedidaPreventivaCultural medidaPreventivaCultural)
        {
          if (_context.MedidaPreventivaCulturals == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.MedidaPreventivaCulturals'  is null.");
          }
            _context.MedidaPreventivaCulturals.Add(medidaPreventivaCultural);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedidaPreventivaCulturalExists(medidaPreventivaCultural.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedidaPreventivaCultural", new { id = medidaPreventivaCultural.CodigoSiex }, medidaPreventivaCultural);
        }

        // DELETE: api/MedidaPreventivaCulturals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedidaPreventivaCultural(int id)
        {
            if (_context.MedidaPreventivaCulturals == null)
            {
                return NotFound();
            }
            var medidaPreventivaCultural = await _context.MedidaPreventivaCulturals.FindAsync(id);
            if (medidaPreventivaCultural == null)
            {
                return NotFound();
            }

            _context.MedidaPreventivaCulturals.Remove(medidaPreventivaCultural);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedidaPreventivaCulturalExists(int id)
        {
            return (_context.MedidaPreventivaCulturals?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
