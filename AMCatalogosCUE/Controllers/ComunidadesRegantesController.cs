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
    public class ComunidadesRegantesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ComunidadesRegantesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ComunidadesRegantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunidadesRegante>>> GetComunidadesRegantes()
        {
          if (_context.ComunidadesRegantes == null)
          {
              return NotFound();
          }
            return await _context.ComunidadesRegantes.ToListAsync();
        }

        // GET: api/ComunidadesRegantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComunidadesRegante>> GetComunidadesRegante(int id)
        {
          if (_context.ComunidadesRegantes == null)
          {
              return NotFound();
          }
            var comunidadesRegante = await _context.ComunidadesRegantes.FindAsync(id);

            if (comunidadesRegante == null)
            {
                return NotFound();
            }

            return comunidadesRegante;
        }

        // PUT: api/ComunidadesRegantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunidadesRegante(int id, ComunidadesRegante comunidadesRegante)
        {
            if (id != comunidadesRegante.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(comunidadesRegante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunidadesReganteExists(id))
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

        // POST: api/ComunidadesRegantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComunidadesRegante>> PostComunidadesRegante(ComunidadesRegante comunidadesRegante)
        {
          if (_context.ComunidadesRegantes == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ComunidadesRegantes'  is null.");
          }
            _context.ComunidadesRegantes.Add(comunidadesRegante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComunidadesReganteExists(comunidadesRegante.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComunidadesRegante", new { id = comunidadesRegante.CodigoSiex }, comunidadesRegante);
        }

        // DELETE: api/ComunidadesRegantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunidadesRegante(int id)
        {
            if (_context.ComunidadesRegantes == null)
            {
                return NotFound();
            }
            var comunidadesRegante = await _context.ComunidadesRegantes.FindAsync(id);
            if (comunidadesRegante == null)
            {
                return NotFound();
            }

            _context.ComunidadesRegantes.Remove(comunidadesRegante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunidadesReganteExists(int id)
        {
            return (_context.ComunidadesRegantes?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
