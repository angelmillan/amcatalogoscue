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
    public class EmpresaProdSemillasCertificsController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public EmpresaProdSemillasCertificsController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/EmpresaProdSemillasCertifics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaProdSemillasCertific>>> GetEmpresaProdSemillasCertifics()
        {
          if (_context.EmpresaProdSemillasCertifics == null)
          {
              return NotFound();
          }
            return await _context.EmpresaProdSemillasCertifics.ToListAsync();
        }

        // GET: api/EmpresaProdSemillasCertifics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaProdSemillasCertific>> GetEmpresaProdSemillasCertific(int id)
        {
          if (_context.EmpresaProdSemillasCertifics == null)
          {
              return NotFound();
          }
            var empresaProdSemillasCertific = await _context.EmpresaProdSemillasCertifics.FindAsync(id);

            if (empresaProdSemillasCertific == null)
            {
                return NotFound();
            }

            return empresaProdSemillasCertific;
        }

        // PUT: api/EmpresaProdSemillasCertifics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaProdSemillasCertific(int id, EmpresaProdSemillasCertific empresaProdSemillasCertific)
        {
            if (id != empresaProdSemillasCertific.CodigoAsociacion)
            {
                return BadRequest();
            }

            _context.Entry(empresaProdSemillasCertific).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaProdSemillasCertificExists(id))
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

        // POST: api/EmpresaProdSemillasCertifics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpresaProdSemillasCertific>> PostEmpresaProdSemillasCertific(EmpresaProdSemillasCertific empresaProdSemillasCertific)
        {
          if (_context.EmpresaProdSemillasCertifics == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.EmpresaProdSemillasCertifics'  is null.");
          }
            _context.EmpresaProdSemillasCertifics.Add(empresaProdSemillasCertific);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpresaProdSemillasCertificExists(empresaProdSemillasCertific.CodigoAsociacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpresaProdSemillasCertific", new { id = empresaProdSemillasCertific.CodigoAsociacion }, empresaProdSemillasCertific);
        }

        // DELETE: api/EmpresaProdSemillasCertifics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaProdSemillasCertific(int id)
        {
            if (_context.EmpresaProdSemillasCertifics == null)
            {
                return NotFound();
            }
            var empresaProdSemillasCertific = await _context.EmpresaProdSemillasCertifics.FindAsync(id);
            if (empresaProdSemillasCertific == null)
            {
                return NotFound();
            }

            _context.EmpresaProdSemillasCertifics.Remove(empresaProdSemillasCertific);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaProdSemillasCertificExists(int id)
        {
            return (_context.EmpresaProdSemillasCertifics?.Any(e => e.CodigoAsociacion == id)).GetValueOrDefault();
        }
    }
}
