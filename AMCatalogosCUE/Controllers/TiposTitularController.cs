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
    public class TiposTitularController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposTitularController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoTitulars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTitular>>> GetTipoTitulars()
        {
          if (_context.TipoTitulars == null)
          {
              return NotFound();
          }
            return await _context.TipoTitulars.ToListAsync();
        }

        // GET: api/TipoTitulars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTitular>> GetTipoTitular(int id)
        {
          if (_context.TipoTitulars == null)
          {
              return NotFound();
          }
            var tipoTitular = await _context.TipoTitulars.FindAsync(id);

            if (tipoTitular == null)
            {
                return NotFound();
            }

            return tipoTitular;
        }

        // PUT: api/TipoTitulars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTitular(int id, TipoTitular tipoTitular)
        {
            if (id != tipoTitular.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoTitular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTitularExists(id))
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

        // POST: api/TipoTitulars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTitular>> PostTipoTitular(TipoTitular tipoTitular)
        {
          if (_context.TipoTitulars == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoTitulars'  is null.");
          }
            _context.TipoTitulars.Add(tipoTitular);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoTitularExists(tipoTitular.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoTitular", new { id = tipoTitular.CodigoSiex }, tipoTitular);
        }

        // DELETE: api/TipoTitulars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTitular(int id)
        {
            if (_context.TipoTitulars == null)
            {
                return NotFound();
            }
            var tipoTitular = await _context.TipoTitulars.FindAsync(id);
            if (tipoTitular == null)
            {
                return NotFound();
            }

            _context.TipoTitulars.Remove(tipoTitular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTitularExists(int id)
        {
            return (_context.TipoTitulars?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
