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
    public class FinalidadCosechasController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public FinalidadCosechasController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/FinalidadCosechas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinalidadCosecha>>> GetFinalidadCosechas()
        {
          if (_context.FinalidadCosechas == null)
          {
              return NotFound();
          }
            return await _context.FinalidadCosechas.ToListAsync();
        }

        // GET: api/FinalidadCosechas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinalidadCosecha>> GetFinalidadCosecha(int id)
        {
          if (_context.FinalidadCosechas == null)
          {
              return NotFound();
          }
            var finalidadCosecha = await _context.FinalidadCosechas.FindAsync(id);

            if (finalidadCosecha == null)
            {
                return NotFound();
            }

            return finalidadCosecha;
        }

        // PUT: api/FinalidadCosechas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinalidadCosecha(int id, FinalidadCosecha finalidadCosecha)
        {
            if (id != finalidadCosecha.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(finalidadCosecha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalidadCosechaExists(id))
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

        // POST: api/FinalidadCosechas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinalidadCosecha>> PostFinalidadCosecha(FinalidadCosecha finalidadCosecha)
        {
          if (_context.FinalidadCosechas == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.FinalidadCosechas'  is null.");
          }
            _context.FinalidadCosechas.Add(finalidadCosecha);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FinalidadCosechaExists(finalidadCosecha.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFinalidadCosecha", new { id = finalidadCosecha.CodigoSiex }, finalidadCosecha);
        }

        // DELETE: api/FinalidadCosechas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinalidadCosecha(int id)
        {
            if (_context.FinalidadCosechas == null)
            {
                return NotFound();
            }
            var finalidadCosecha = await _context.FinalidadCosechas.FindAsync(id);
            if (finalidadCosecha == null)
            {
                return NotFound();
            }

            _context.FinalidadCosechas.Remove(finalidadCosecha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinalidadCosechaExists(int id)
        {
            return (_context.FinalidadCosechas?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
