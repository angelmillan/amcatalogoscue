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
    public class ActividadSobreCubiertaController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ActividadSobreCubiertaController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ActividadSobreCubiertums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadSobreCubiertum>>> GetActividadSobreCubierta()
        {
          if (_context.ActividadSobreCubierta == null)
          {
              return NotFound();
          }
            return await _context.ActividadSobreCubierta.ToListAsync();
        }

        // GET: api/ActividadSobreCubiertums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadSobreCubiertum>> GetActividadSobreCubiertum(int id)
        {
          if (_context.ActividadSobreCubierta == null)
          {
              return NotFound();
          }
            var actividadSobreCubiertum = await _context.ActividadSobreCubierta.FindAsync(id);

            if (actividadSobreCubiertum == null)
            {
                return NotFound();
            }

            return actividadSobreCubiertum;
        }

        // PUT: api/ActividadSobreCubiertums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividadSobreCubiertum(int id, ActividadSobreCubiertum actividadSobreCubiertum)
        {
            if (id != actividadSobreCubiertum.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(actividadSobreCubiertum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadSobreCubiertumExists(id))
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

        // POST: api/ActividadSobreCubiertums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActividadSobreCubiertum>> PostActividadSobreCubiertum(ActividadSobreCubiertum actividadSobreCubiertum)
        {
          if (_context.ActividadSobreCubierta == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ActividadSobreCubierta'  is null.");
          }
            _context.ActividadSobreCubierta.Add(actividadSobreCubiertum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActividadSobreCubiertumExists(actividadSobreCubiertum.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActividadSobreCubiertum", new { id = actividadSobreCubiertum.CodigoSiex }, actividadSobreCubiertum);
        }

        // DELETE: api/ActividadSobreCubiertums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividadSobreCubiertum(int id)
        {
            if (_context.ActividadSobreCubierta == null)
            {
                return NotFound();
            }
            var actividadSobreCubiertum = await _context.ActividadSobreCubierta.FindAsync(id);
            if (actividadSobreCubiertum == null)
            {
                return NotFound();
            }

            _context.ActividadSobreCubierta.Remove(actividadSobreCubiertum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadSobreCubiertumExists(int id)
        {
            return (_context.ActividadSobreCubierta?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
