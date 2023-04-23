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
    public class EdificacionesInstalacionesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public EdificacionesInstalacionesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/EdificacionesInstalaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EdificacionesInstalacione>>> GetEdificacionesInstalaciones()
        {
          if (_context.EdificacionesInstalaciones == null)
          {
              return NotFound();
          }
            return await _context.EdificacionesInstalaciones.ToListAsync();
        }

        // GET: api/EdificacionesInstalaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EdificacionesInstalacione>> GetEdificacionesInstalacione(int id)
        {
          if (_context.EdificacionesInstalaciones == null)
          {
              return NotFound();
          }
            var edificacionesInstalacione = await _context.EdificacionesInstalaciones.FindAsync(id);

            if (edificacionesInstalacione == null)
            {
                return NotFound();
            }

            return edificacionesInstalacione;
        }

        // PUT: api/EdificacionesInstalaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEdificacionesInstalacione(int id, EdificacionesInstalacione edificacionesInstalacione)
        {
            if (id != edificacionesInstalacione.SubCodigo)
            {
                return BadRequest();
            }

            _context.Entry(edificacionesInstalacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EdificacionesInstalacioneExists(id))
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

        // POST: api/EdificacionesInstalaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EdificacionesInstalacione>> PostEdificacionesInstalacione(EdificacionesInstalacione edificacionesInstalacione)
        {
          if (_context.EdificacionesInstalaciones == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.EdificacionesInstalaciones'  is null.");
          }
            _context.EdificacionesInstalaciones.Add(edificacionesInstalacione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EdificacionesInstalacioneExists(edificacionesInstalacione.SubCodigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEdificacionesInstalacione", new { id = edificacionesInstalacione.SubCodigo }, edificacionesInstalacione);
        }

        // DELETE: api/EdificacionesInstalaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEdificacionesInstalacione(int id)
        {
            if (_context.EdificacionesInstalaciones == null)
            {
                return NotFound();
            }
            var edificacionesInstalacione = await _context.EdificacionesInstalaciones.FindAsync(id);
            if (edificacionesInstalacione == null)
            {
                return NotFound();
            }

            _context.EdificacionesInstalaciones.Remove(edificacionesInstalacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EdificacionesInstalacioneExists(int id)
        {
            return (_context.EdificacionesInstalaciones?.Any(e => e.SubCodigo == id)).GetValueOrDefault();
        }
    }
}
