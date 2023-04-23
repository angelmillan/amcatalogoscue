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
    public class MaterialAnalizadoController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public MaterialAnalizadoController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/MaterialAnalizadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialAnalizado>>> GetMaterialAnalizados()
        {
          if (_context.MaterialAnalizados == null)
          {
              return NotFound();
          }
            return await _context.MaterialAnalizados.ToListAsync();
        }

        // GET: api/MaterialAnalizadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialAnalizado>> GetMaterialAnalizado(int id)
        {
          if (_context.MaterialAnalizados == null)
          {
              return NotFound();
          }
            var materialAnalizado = await _context.MaterialAnalizados.FindAsync(id);

            if (materialAnalizado == null)
            {
                return NotFound();
            }

            return materialAnalizado;
        }

        // PUT: api/MaterialAnalizadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialAnalizado(int id, MaterialAnalizado materialAnalizado)
        {
            if (id != materialAnalizado.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(materialAnalizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialAnalizadoExists(id))
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

        // POST: api/MaterialAnalizadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaterialAnalizado>> PostMaterialAnalizado(MaterialAnalizado materialAnalizado)
        {
          if (_context.MaterialAnalizados == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.MaterialAnalizados'  is null.");
          }
            _context.MaterialAnalizados.Add(materialAnalizado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaterialAnalizadoExists(materialAnalizado.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterialAnalizado", new { id = materialAnalizado.CodigoSiex }, materialAnalizado);
        }

        // DELETE: api/MaterialAnalizadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialAnalizado(int id)
        {
            if (_context.MaterialAnalizados == null)
            {
                return NotFound();
            }
            var materialAnalizado = await _context.MaterialAnalizados.FindAsync(id);
            if (materialAnalizado == null)
            {
                return NotFound();
            }

            _context.MaterialAnalizados.Remove(materialAnalizado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialAnalizadoExists(int id)
        {
            return (_context.MaterialAnalizados?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
