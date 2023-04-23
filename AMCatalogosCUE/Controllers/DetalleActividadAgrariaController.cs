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
    public class DetalleActividadAgrariaController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public DetalleActividadAgrariaController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/DetalleActividadAgrariums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleActividadAgrarium>>> GetDetalleActividadAgraria()
        {
          if (_context.DetalleActividadAgraria == null)
          {
              return NotFound();
          }
            return await _context.DetalleActividadAgraria.ToListAsync();
        }

        // GET: api/DetalleActividadAgrariums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleActividadAgrarium>> GetDetalleActividadAgrarium(int id)
        {
          if (_context.DetalleActividadAgraria == null)
          {
              return NotFound();
          }
            var detalleActividadAgrarium = await _context.DetalleActividadAgraria.FindAsync(id);

            if (detalleActividadAgrarium == null)
            {
                return NotFound();
            }

            return detalleActividadAgrarium;
        }

        // PUT: api/DetalleActividadAgrariums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleActividadAgrarium(int id, DetalleActividadAgrarium detalleActividadAgrarium)
        {
            if (id != detalleActividadAgrarium.SubCodigo)
            {
                return BadRequest();
            }

            _context.Entry(detalleActividadAgrarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleActividadAgrariumExists(id))
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

        // POST: api/DetalleActividadAgrariums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleActividadAgrarium>> PostDetalleActividadAgrarium(DetalleActividadAgrarium detalleActividadAgrarium)
        {
          if (_context.DetalleActividadAgraria == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.DetalleActividadAgraria'  is null.");
          }
            _context.DetalleActividadAgraria.Add(detalleActividadAgrarium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetalleActividadAgrariumExists(detalleActividadAgrarium.SubCodigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetalleActividadAgrarium", new { id = detalleActividadAgrarium.SubCodigo }, detalleActividadAgrarium);
        }

        // DELETE: api/DetalleActividadAgrariums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleActividadAgrarium(int id)
        {
            if (_context.DetalleActividadAgraria == null)
            {
                return NotFound();
            }
            var detalleActividadAgrarium = await _context.DetalleActividadAgraria.FindAsync(id);
            if (detalleActividadAgrarium == null)
            {
                return NotFound();
            }

            _context.DetalleActividadAgraria.Remove(detalleActividadAgrarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleActividadAgrariumExists(int id)
        {
            return (_context.DetalleActividadAgraria?.Any(e => e.SubCodigo == id)).GetValueOrDefault();
        }
    }
}
