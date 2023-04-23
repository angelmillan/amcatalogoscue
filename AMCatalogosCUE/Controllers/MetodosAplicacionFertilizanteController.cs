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
    public class MetodosAplicacionFertilizanteController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public MetodosAplicacionFertilizanteController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/MetodoAplicacionFertilizantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoAplicacionFertilizante>>> GetMetodoAplicacionFertilizantes()
        {
          if (_context.MetodoAplicacionFertilizantes == null)
          {
              return NotFound();
          }
            return await _context.MetodoAplicacionFertilizantes.ToListAsync();
        }

        // GET: api/MetodoAplicacionFertilizantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoAplicacionFertilizante>> GetMetodoAplicacionFertilizante(int id)
        {
          if (_context.MetodoAplicacionFertilizantes == null)
          {
              return NotFound();
          }
            var metodoAplicacionFertilizante = await _context.MetodoAplicacionFertilizantes.FindAsync(id);

            if (metodoAplicacionFertilizante == null)
            {
                return NotFound();
            }

            return metodoAplicacionFertilizante;
        }

        // PUT: api/MetodoAplicacionFertilizantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoAplicacionFertilizante(int id, MetodoAplicacionFertilizante metodoAplicacionFertilizante)
        {
            if (id != metodoAplicacionFertilizante.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(metodoAplicacionFertilizante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoAplicacionFertilizanteExists(id))
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

        // POST: api/MetodoAplicacionFertilizantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetodoAplicacionFertilizante>> PostMetodoAplicacionFertilizante(MetodoAplicacionFertilizante metodoAplicacionFertilizante)
        {
          if (_context.MetodoAplicacionFertilizantes == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.MetodoAplicacionFertilizantes'  is null.");
          }
            _context.MetodoAplicacionFertilizantes.Add(metodoAplicacionFertilizante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MetodoAplicacionFertilizanteExists(metodoAplicacionFertilizante.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMetodoAplicacionFertilizante", new { id = metodoAplicacionFertilizante.CodigoSiex }, metodoAplicacionFertilizante);
        }

        // DELETE: api/MetodoAplicacionFertilizantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoAplicacionFertilizante(int id)
        {
            if (_context.MetodoAplicacionFertilizantes == null)
            {
                return NotFound();
            }
            var metodoAplicacionFertilizante = await _context.MetodoAplicacionFertilizantes.FindAsync(id);
            if (metodoAplicacionFertilizante == null)
            {
                return NotFound();
            }

            _context.MetodoAplicacionFertilizantes.Remove(metodoAplicacionFertilizante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetodoAplicacionFertilizanteExists(int id)
        {
            return (_context.MetodoAplicacionFertilizantes?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
