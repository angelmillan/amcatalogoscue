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
    public class EntidadCertificacionController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public EntidadCertificacionController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/EntidadCertificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntidadCertificacion>>> GetEntidadCertificacions()
        {
          if (_context.EntidadCertificacions == null)
          {
              return NotFound();
          }
            return await _context.EntidadCertificacions.ToListAsync();
        }

        // GET: api/EntidadCertificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntidadCertificacion>> GetEntidadCertificacion(string id)
        {
          if (_context.EntidadCertificacions == null)
          {
              return NotFound();
          }
            var entidadCertificacion = await _context.EntidadCertificacions.FindAsync(id);

            if (entidadCertificacion == null)
            {
                return NotFound();
            }

            return entidadCertificacion;
        }

        // PUT: api/EntidadCertificacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidadCertificacion(string id, EntidadCertificacion entidadCertificacion)
        {
            if (id != entidadCertificacion.CodigoAsociacion)
            {
                return BadRequest();
            }

            _context.Entry(entidadCertificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadCertificacionExists(id))
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

        // POST: api/EntidadCertificacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntidadCertificacion>> PostEntidadCertificacion(EntidadCertificacion entidadCertificacion)
        {
          if (_context.EntidadCertificacions == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.EntidadCertificacions'  is null.");
          }
            _context.EntidadCertificacions.Add(entidadCertificacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntidadCertificacionExists(entidadCertificacion.CodigoAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntidadCertificacion", new { id = entidadCertificacion.CodigoAsociacion }, entidadCertificacion);
        }

        // DELETE: api/EntidadCertificacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidadCertificacion(string id)
        {
            if (_context.EntidadCertificacions == null)
            {
                return NotFound();
            }
            var entidadCertificacion = await _context.EntidadCertificacions.FindAsync(id);
            if (entidadCertificacion == null)
            {
                return NotFound();
            }

            _context.EntidadCertificacions.Remove(entidadCertificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntidadCertificacionExists(string id)
        {
            return (_context.EntidadCertificacions?.Any(e => e.CodigoAsociacion == id)).GetValueOrDefault();
        }
    }
}
