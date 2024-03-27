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
    public class OrdenProduccionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdenProduccionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdenProduccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenProduccion>>> GetordenProduccions()
        {
            return await _context.ordenProduccions.ToListAsync();
        }

        // GET: api/OrdenProduccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenProduccion>> GetOrdenProduccion(int id)
        {
            var ordenProduccion = await _context.ordenProduccions.FindAsync(id);

            if (ordenProduccion == null)
            {
                return NotFound();
            }

            return ordenProduccion;
        }

        // PUT: api/OrdenProduccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenProduccion(int id, OrdenProduccion ordenProduccion)
        {
            if (id != ordenProduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenProduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenProduccionExists(id))
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

        // POST: api/OrdenProduccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenProduccion>> PostOrdenProduccion(OrdenProduccion ordenProduccion)
        {
            _context.ordenProduccions.Add(ordenProduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenProduccion", new { id = ordenProduccion.Id }, ordenProduccion);
        }

        // DELETE: api/OrdenProduccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenProduccion(int id)
        {
            var ordenProduccion = await _context.ordenProduccions.FindAsync(id);
            if (ordenProduccion == null)
            {
                return NotFound();
            }

            _context.ordenProduccions.Remove(ordenProduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenProduccionExists(int id)
        {
            return _context.ordenProduccions.Any(e => e.Id == id);
        }
    }
}
