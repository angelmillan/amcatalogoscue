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
    public class TiposAgricultorController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public TiposAgricultorController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/TipoAgricultors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAgricultor>>> GetTipoAgricultors()
        {
          if (_context.TipoAgricultors == null)
          {
              return NotFound();
          }
            return await _context.TipoAgricultors.ToListAsync();
        }

        // GET: api/TipoAgricultors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAgricultor>> GetTipoAgricultor(int id)
        {
          if (_context.TipoAgricultors == null)
          {
              return NotFound();
          }
            var tipoAgricultor = await _context.TipoAgricultors.FindAsync(id);

            if (tipoAgricultor == null)
            {
                return NotFound();
            }

            return tipoAgricultor;
        }

        // PUT: api/TipoAgricultors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAgricultor(int id, TipoAgricultor tipoAgricultor)
        {
            if (id != tipoAgricultor.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(tipoAgricultor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAgricultorExists(id))
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

        // POST: api/TipoAgricultors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoAgricultor>> PostTipoAgricultor(TipoAgricultor tipoAgricultor)
        {
          if (_context.TipoAgricultors == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.TipoAgricultors'  is null.");
          }
            _context.TipoAgricultors.Add(tipoAgricultor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoAgricultorExists(tipoAgricultor.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoAgricultor", new { id = tipoAgricultor.CodigoSiex }, tipoAgricultor);
        }

        // DELETE: api/TipoAgricultors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAgricultor(int id)
        {
            if (_context.TipoAgricultors == null)
            {
                return NotFound();
            }
            var tipoAgricultor = await _context.TipoAgricultors.FindAsync(id);
            if (tipoAgricultor == null)
            {
                return NotFound();
            }

            _context.TipoAgricultors.Remove(tipoAgricultor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoAgricultorExists(int id)
        {
            return (_context.TipoAgricultors?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
