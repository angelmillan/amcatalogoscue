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
    public class TipoAnalisisController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TipoAnalisisController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoAnalisis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAnalisi>>> GetTipoAnalises()
        {
          if (_context.TipoAnalises == null)
          {
              return NotFound();
          }
            return await _context.TipoAnalises.ToListAsync();
        }

        // GET: api/TipoAnalisis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAnalisi>> GetTipoAnalisi(int id)
        {
          if (_context.TipoAnalises == null)
          {
              return NotFound();
          }
            var tipoAnalisi = await _context.TipoAnalises.FindAsync(id);

            if (tipoAnalisi == null)
            {
                return NotFound();
            }

            return tipoAnalisi;
        }

        // PUT: api/TipoAnalisis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAnalisi(int id, TipoAnalisi tipoAnalisi)
        {
            if (id != tipoAnalisi.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoAnalisi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAnalisiExists(id))
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

        // POST: api/TipoAnalisis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoAnalisi>> PostTipoAnalisi(TipoAnalisi tipoAnalisi)
        {
          if (_context.TipoAnalises == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoAnalises'  is null.");
          }
            _context.TipoAnalises.Add(tipoAnalisi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoAnalisiExists(tipoAnalisi.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoAnalisi", new { id = tipoAnalisi.CodigoSiex }, tipoAnalisi);
        }

        // DELETE: api/TipoAnalisis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAnalisi(int id)
        {
            if (_context.TipoAnalises == null)
            {
                return NotFound();
            }
            var tipoAnalisi = await _context.TipoAnalises.FindAsync(id);
            if (tipoAnalisi == null)
            {
                return NotFound();
            }

            _context.TipoAnalises.Remove(tipoAnalisi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoAnalisiExists(int id)
        {
            return (_context.TipoAnalises?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
