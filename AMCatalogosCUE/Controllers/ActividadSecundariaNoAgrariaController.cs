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
    public class ActividadSecundariaNoAgrariaController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ActividadSecundariaNoAgrariaController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ActividadSecundariaNoAgrariums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadSecundariaNoAgrarium>>> GetActividadSecundariaNoAgraria()
        {
          if (_context.ActividadSecundariaNoAgraria == null)
          {
              return NotFound();
          }
            return await _context.ActividadSecundariaNoAgraria.ToListAsync();
        }

        // GET: api/ActividadSecundariaNoAgrariums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadSecundariaNoAgrarium>> GetActividadSecundariaNoAgrarium(string id)
        {
          if (_context.ActividadSecundariaNoAgraria == null)
          {
              return NotFound();
          }
            var actividadSecundariaNoAgrarium = await _context.ActividadSecundariaNoAgraria.FindAsync(id);

            if (actividadSecundariaNoAgrarium == null)
            {
                return NotFound();
            }

            return actividadSecundariaNoAgrarium;
        }

        // PUT: api/ActividadSecundariaNoAgrariums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividadSecundariaNoAgrarium(string id, ActividadSecundariaNoAgrarium actividadSecundariaNoAgrarium)
        {
            if (id != actividadSecundariaNoAgrarium.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(actividadSecundariaNoAgrarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadSecundariaNoAgrariumExists(id))
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

        // POST: api/ActividadSecundariaNoAgrariums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActividadSecundariaNoAgrarium>> PostActividadSecundariaNoAgrarium(ActividadSecundariaNoAgrarium actividadSecundariaNoAgrarium)
        {
          if (_context.ActividadSecundariaNoAgraria == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ActividadSecundariaNoAgraria'  is null.");
          }
            _context.ActividadSecundariaNoAgraria.Add(actividadSecundariaNoAgrarium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActividadSecundariaNoAgrariumExists(actividadSecundariaNoAgrarium.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActividadSecundariaNoAgrarium", new { id = actividadSecundariaNoAgrarium.CodigoSiex }, actividadSecundariaNoAgrarium);
        }

        // DELETE: api/ActividadSecundariaNoAgrariums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividadSecundariaNoAgrarium(string id)
        {
            if (_context.ActividadSecundariaNoAgraria == null)
            {
                return NotFound();
            }
            var actividadSecundariaNoAgrarium = await _context.ActividadSecundariaNoAgraria.FindAsync(id);
            if (actividadSecundariaNoAgrarium == null)
            {
                return NotFound();
            }

            _context.ActividadSecundariaNoAgraria.Remove(actividadSecundariaNoAgrarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadSecundariaNoAgrariumExists(string id)
        {
            return (_context.ActividadSecundariaNoAgraria?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
