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
    public class ProductosVegetalesController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public ProductosVegetalesController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/ProductoVegetals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoVegetal>>> GetProductoVegetals()
        {
          if (_context.ProductoVegetals == null)
          {
              return NotFound();
          }
            return await _context.ProductoVegetals.ToListAsync();
        }

        // GET: api/ProductoVegetals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoVegetal>> GetProductoVegetal(string id)
        {
          if (_context.ProductoVegetals == null)
          {
              return NotFound();
          }
            var productoVegetal = await _context.ProductoVegetals.FindAsync(id);

            if (productoVegetal == null)
            {
                return NotFound();
            }

            return productoVegetal;
        }

        // PUT: api/ProductoVegetals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoVegetal(string id, ProductoVegetal productoVegetal)
        {
            if (id != productoVegetal.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(productoVegetal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoVegetalExists(id))
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

        // POST: api/ProductoVegetals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoVegetal>> PostProductoVegetal(ProductoVegetal productoVegetal)
        {
          if (_context.ProductoVegetals == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.ProductoVegetals'  is null.");
          }
            _context.ProductoVegetals.Add(productoVegetal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoVegetalExists(productoVegetal.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductoVegetal", new { id = productoVegetal.Codigo }, productoVegetal);
        }

        // DELETE: api/ProductoVegetals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoVegetal(string id)
        {
            if (_context.ProductoVegetals == null)
            {
                return NotFound();
            }
            var productoVegetal = await _context.ProductoVegetals.FindAsync(id);
            if (productoVegetal == null)
            {
                return NotFound();
            }

            _context.ProductoVegetals.Remove(productoVegetal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoVegetalExists(string id)
        {
            return (_context.ProductoVegetals?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
