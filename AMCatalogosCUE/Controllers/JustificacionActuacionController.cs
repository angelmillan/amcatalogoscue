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
    public class JustificacionActuacionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public JustificacionActuacionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/JustificacionActuacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JustificacionActuacion>>> GetJustificacionActuacions()
        {
          if (_context.JustificacionActuacions == null)
          {
              return NotFound();
          }
            return await _context.JustificacionActuacions.ToListAsync();
        }

        // GET: api/JustificacionActuacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JustificacionActuacion>> GetJustificacionActuacion(int id)
        {
          if (_context.JustificacionActuacions == null)
          {
              return NotFound();
          }
            var justificacionActuacion = await _context.JustificacionActuacions.FindAsync(id);

            if (justificacionActuacion == null)
            {
                return NotFound();
            }

            return justificacionActuacion;
        }

        // PUT: api/JustificacionActuacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJustificacionActuacion(int id, JustificacionActuacion justificacionActuacion)
        {
            if (id != justificacionActuacion.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(justificacionActuacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JustificacionActuacionExists(id))
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

        // POST: api/JustificacionActuacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JustificacionActuacion>> PostJustificacionActuacion(JustificacionActuacion justificacionActuacion)
        {
          if (_context.JustificacionActuacions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.JustificacionActuacions'  is null.");
          }
            _context.JustificacionActuacions.Add(justificacionActuacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JustificacionActuacionExists(justificacionActuacion.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJustificacionActuacion", new { id = justificacionActuacion.CodigoSiex }, justificacionActuacion);
        }

        // DELETE: api/JustificacionActuacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJustificacionActuacion(int id)
        {
            if (_context.JustificacionActuacions == null)
            {
                return NotFound();
            }
            var justificacionActuacion = await _context.JustificacionActuacions.FindAsync(id);
            if (justificacionActuacion == null)
            {
                return NotFound();
            }

            _context.JustificacionActuacions.Remove(justificacionActuacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JustificacionActuacionExists(int id)
        {
            return (_context.JustificacionActuacions?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
