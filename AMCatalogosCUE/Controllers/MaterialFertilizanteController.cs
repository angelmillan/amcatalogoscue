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
    public class MaterialFertilizanteController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public MaterialFertilizanteController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/MaterialFertilizantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialFertilizante>>> GetMaterialFertilizantes()
        {
          if (_context.MaterialFertilizantes == null)
          {
              return NotFound();
          }
            return await _context.MaterialFertilizantes.ToListAsync();
        }

        // GET: api/MaterialFertilizantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialFertilizante>> GetMaterialFertilizante(int id)
        {
          if (_context.MaterialFertilizantes == null)
          {
              return NotFound();
          }
            var materialFertilizante = await _context.MaterialFertilizantes.FindAsync(id);

            if (materialFertilizante == null)
            {
                return NotFound();
            }

            return materialFertilizante;
        }

        // PUT: api/MaterialFertilizantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialFertilizante(int id, MaterialFertilizante materialFertilizante)
        {
            if (id != materialFertilizante.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(materialFertilizante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialFertilizanteExists(id))
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

        // POST: api/MaterialFertilizantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaterialFertilizante>> PostMaterialFertilizante(MaterialFertilizante materialFertilizante)
        {
          if (_context.MaterialFertilizantes == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.MaterialFertilizantes'  is null.");
          }
            _context.MaterialFertilizantes.Add(materialFertilizante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaterialFertilizanteExists(materialFertilizante.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterialFertilizante", new { id = materialFertilizante.CodigoSiex }, materialFertilizante);
        }

        // DELETE: api/MaterialFertilizantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialFertilizante(int id)
        {
            if (_context.MaterialFertilizantes == null)
            {
                return NotFound();
            }
            var materialFertilizante = await _context.MaterialFertilizantes.FindAsync(id);
            if (materialFertilizante == null)
            {
                return NotFound();
            }

            _context.MaterialFertilizantes.Remove(materialFertilizante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialFertilizanteExists(int id)
        {
            return (_context.MaterialFertilizantes?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
