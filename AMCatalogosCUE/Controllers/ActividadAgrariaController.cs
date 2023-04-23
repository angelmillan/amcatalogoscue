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
    public class ActividadAgrariaController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ActividadAgrariaController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ActividadAgrariums
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<ActividadAgrarium>>> GetActividadAgraria()
        {
          if (_context.ActividadAgraria == null)
          {
              return NotFound();
          }
            return await _context.ActividadAgraria.ToListAsync();
        }

        // GET: api/ActividadAgrariums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadAgrarium>> GetActividadAgrarium(int id)
        {
          if (_context.ActividadAgraria == null)
          {
              return NotFound();
          }
            var actividadAgrarium = await _context.ActividadAgraria.FindAsync(id);

            if (actividadAgrarium == null)
            {
                return NotFound();
            }

            return actividadAgrarium;
        }

        // PUT: api/ActividadAgrariums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividadAgrarium(int id, ActividadAgrarium actividadAgrarium)
        {
            if (id != actividadAgrarium.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(actividadAgrarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadAgrariumExists(id))
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

        // POST: api/ActividadAgrariums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActividadAgrarium>> PostActividadAgrarium(ActividadAgrarium actividadAgrarium)
        {
          if (_context.ActividadAgraria == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ActividadAgraria'  is null.");
          }
            _context.ActividadAgraria.Add(actividadAgrarium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActividadAgrariumExists(actividadAgrarium.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActividadAgrarium", new { id = actividadAgrarium.CodigoSiex }, actividadAgrarium);
        }

        // DELETE: api/ActividadAgrariums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividadAgrarium(int id)
        {
            if (_context.ActividadAgraria == null)
            {
                return NotFound();
            }
            var actividadAgrarium = await _context.ActividadAgraria.FindAsync(id);
            if (actividadAgrarium == null)
            {
                return NotFound();
            }

            _context.ActividadAgraria.Remove(actividadAgrarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadAgrariumExists(int id)
        {
            return (_context.ActividadAgraria?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
