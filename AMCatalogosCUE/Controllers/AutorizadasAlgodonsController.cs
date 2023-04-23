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
    public class AutorizadasAlgodonController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public AutorizadasAlgodonController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/AutorizadasAlgodons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorizadasAlgodon>>> GetAutorizadasAlgodons()
        {
          if (_context.AutorizadasAlgodons == null)
          {
              return NotFound();
          }
            return await _context.AutorizadasAlgodons.ToListAsync();
        }

        // GET: api/AutorizadasAlgodons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorizadasAlgodon>> GetAutorizadasAlgodon(int id)
        {
          if (_context.AutorizadasAlgodons == null)
          {
              return NotFound();
          }
            var autorizadasAlgodon = await _context.AutorizadasAlgodons.FindAsync(id);

            if (autorizadasAlgodon == null)
            {
                return NotFound();
            }

            return autorizadasAlgodon;
        }

        // PUT: api/AutorizadasAlgodons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutorizadasAlgodon(int id, AutorizadasAlgodon autorizadasAlgodon)
        {
            if (id != autorizadasAlgodon.CodigoAsociacion)
            {
                return BadRequest();
            }

            _context.Entry(autorizadasAlgodon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorizadasAlgodonExists(id))
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

        // POST: api/AutorizadasAlgodons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutorizadasAlgodon>> PostAutorizadasAlgodon(AutorizadasAlgodon autorizadasAlgodon)
        {
          if (_context.AutorizadasAlgodons == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.AutorizadasAlgodons'  is null.");
          }
            _context.AutorizadasAlgodons.Add(autorizadasAlgodon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutorizadasAlgodonExists(autorizadasAlgodon.CodigoAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAutorizadasAlgodon", new { id = autorizadasAlgodon.CodigoAsociacion }, autorizadasAlgodon);
        }

        // DELETE: api/AutorizadasAlgodons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutorizadasAlgodon(int id)
        {
            if (_context.AutorizadasAlgodons == null)
            {
                return NotFound();
            }
            var autorizadasAlgodon = await _context.AutorizadasAlgodons.FindAsync(id);
            if (autorizadasAlgodon == null)
            {
                return NotFound();
            }

            _context.AutorizadasAlgodons.Remove(autorizadasAlgodon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorizadasAlgodonExists(int id)
        {
            return (_context.AutorizadasAlgodons?.Any(e => e.CodigoAsociacion == id)).GetValueOrDefault();
        }
    }
}
