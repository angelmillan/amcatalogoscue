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
    public class TiposMedidaFitosanitariaController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposMedidaFitosanitariaController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoMedidaFitosanitariums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMedidaFitosanitarium>>> GetTipoMedidaFitosanitaria()
        {
          if (_context.TipoMedidaFitosanitaria == null)
          {
              return NotFound();
          }
            return await _context.TipoMedidaFitosanitaria.ToListAsync();
        }

        // GET: api/TipoMedidaFitosanitariums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMedidaFitosanitarium>> GetTipoMedidaFitosanitarium(int id)
        {
          if (_context.TipoMedidaFitosanitaria == null)
          {
              return NotFound();
          }
            var tipoMedidaFitosanitarium = await _context.TipoMedidaFitosanitaria.FindAsync(id);

            if (tipoMedidaFitosanitarium == null)
            {
                return NotFound();
            }

            return tipoMedidaFitosanitarium;
        }

        // PUT: api/TipoMedidaFitosanitariums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMedidaFitosanitarium(int id, TipoMedidaFitosanitarium tipoMedidaFitosanitarium)
        {
            if (id != tipoMedidaFitosanitarium.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoMedidaFitosanitarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMedidaFitosanitariumExists(id))
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

        // POST: api/TipoMedidaFitosanitariums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoMedidaFitosanitarium>> PostTipoMedidaFitosanitarium(TipoMedidaFitosanitarium tipoMedidaFitosanitarium)
        {
          if (_context.TipoMedidaFitosanitaria == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoMedidaFitosanitaria'  is null.");
          }
            _context.TipoMedidaFitosanitaria.Add(tipoMedidaFitosanitarium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoMedidaFitosanitariumExists(tipoMedidaFitosanitarium.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoMedidaFitosanitarium", new { id = tipoMedidaFitosanitarium.CodigoSiex }, tipoMedidaFitosanitarium);
        }

        // DELETE: api/TipoMedidaFitosanitariums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoMedidaFitosanitarium(int id)
        {
            if (_context.TipoMedidaFitosanitaria == null)
            {
                return NotFound();
            }
            var tipoMedidaFitosanitarium = await _context.TipoMedidaFitosanitaria.FindAsync(id);
            if (tipoMedidaFitosanitarium == null)
            {
                return NotFound();
            }

            _context.TipoMedidaFitosanitaria.Remove(tipoMedidaFitosanitarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoMedidaFitosanitariumExists(int id)
        {
            return (_context.TipoMedidaFitosanitaria?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
