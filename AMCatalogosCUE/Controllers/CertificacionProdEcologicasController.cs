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
    public class CertificacionProdEcologicasController : ControllerBase
    {
        private readonly AmsystemRegistroCueContext _context;

        public CertificacionProdEcologicasController(AmsystemRegistroCueContext context)
        {
            _context = context;
        }

        // GET: api/CertificacionProdEcologicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificacionProdEcologica>>> GetCertificacionProdEcologicas()
        {
          if (_context.CertificacionProdEcologicas == null)
          {
              return NotFound();
          }
            return await _context.CertificacionProdEcologicas.ToListAsync();
        }

        // GET: api/CertificacionProdEcologicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificacionProdEcologica>> GetCertificacionProdEcologica(int id)
        {
          if (_context.CertificacionProdEcologicas == null)
          {
              return NotFound();
          }
            var certificacionProdEcologica = await _context.CertificacionProdEcologicas.FindAsync(id);

            if (certificacionProdEcologica == null)
            {
                return NotFound();
            }

            return certificacionProdEcologica;
        }

        // PUT: api/CertificacionProdEcologicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificacionProdEcologica(int id, CertificacionProdEcologica certificacionProdEcologica)
        {
            if (id != certificacionProdEcologica.CodigoSiex)
            {
                return BadRequest();
            }

            _context.Entry(certificacionProdEcologica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificacionProdEcologicaExists(id))
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

        // POST: api/CertificacionProdEcologicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificacionProdEcologica>> PostCertificacionProdEcologica(CertificacionProdEcologica certificacionProdEcologica)
        {
          if (_context.CertificacionProdEcologicas == null)
          {
              return Problem("Entity set 'AmsystemRegistroCueContext.CertificacionProdEcologicas'  is null.");
          }
            _context.CertificacionProdEcologicas.Add(certificacionProdEcologica);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificacionProdEcologicaExists(certificacionProdEcologica.CodigoSiex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificacionProdEcologica", new { id = certificacionProdEcologica.CodigoSiex }, certificacionProdEcologica);
        }

        // DELETE: api/CertificacionProdEcologicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificacionProdEcologica(int id)
        {
            if (_context.CertificacionProdEcologicas == null)
            {
                return NotFound();
            }
            var certificacionProdEcologica = await _context.CertificacionProdEcologicas.FindAsync(id);
            if (certificacionProdEcologica == null)
            {
                return NotFound();
            }

            _context.CertificacionProdEcologicas.Remove(certificacionProdEcologica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificacionProdEcologicaExists(int id)
        {
            return (_context.CertificacionProdEcologicas?.Any(e => e.CodigoSiex == id)).GetValueOrDefault();
        }
    }
}
