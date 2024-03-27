using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDevelopment.Context;
using ApiDevelopment.Models;

namespace ApiDevelopment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenProduccionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetalleOrdenProduccionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DetalleOrdenProduccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOrdenProduccion>>> GetdetalleOrdenProduccion()
        {
            return await _context.detalleOrdenProduccion.ToListAsync();
        }

        // GET: api/DetalleOrdenProduccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrdenProduccion>> GetDetalleOrdenProduccion(int id)
        {
            var detalleOrdenProduccion = await _context.detalleOrdenProduccion.FindAsync(id);

            if (detalleOrdenProduccion == null)
            {
                return NotFound();
            }

            return detalleOrdenProduccion;
        }

        // PUT: api/DetalleOrdenProduccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOrdenProduccion(int id, DetalleOrdenProduccion detalleOrdenProduccion)
        {
            if (id != detalleOrdenProduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleOrdenProduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleOrdenProduccionExists(id))
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

        // POST: api/DetalleOrdenProduccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleOrdenProduccion>> PostDetalleOrdenProduccion(DetalleOrdenProduccion detalleOrdenProduccion)
        {
            _context.detalleOrdenProduccion.Add(detalleOrdenProduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleOrdenProduccion", new { id = detalleOrdenProduccion.Id }, detalleOrdenProduccion);
        }

        // DELETE: api/DetalleOrdenProduccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOrdenProduccion(int id)
        {
            var detalleOrdenProduccion = await _context.detalleOrdenProduccion.FindAsync(id);
            if (detalleOrdenProduccion == null)
            {
                return NotFound();
            }

            _context.detalleOrdenProduccion.Remove(detalleOrdenProduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleOrdenProduccionExists(int id)
        {
            return _context.detalleOrdenProduccion.Any(e => e.Id == id);
        }
    }
}
