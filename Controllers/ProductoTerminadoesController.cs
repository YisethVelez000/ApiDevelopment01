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
    public class ProductoTerminadoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoTerminadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductoTerminadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoTerminado>>> GetProductosTerminados()
        {
            return await _context.ProductosTerminados.ToListAsync();
        }

        // GET: api/ProductoTerminadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoTerminado>> GetProductoTerminado(int id)
        {
            var productoTerminado = await _context.ProductosTerminados.FindAsync(id);

            if (productoTerminado == null)
            {
                return NotFound();
            }

            return productoTerminado;
        }

        // PUT: api/ProductoTerminadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoTerminado(int id, ProductoTerminado productoTerminado)
        {
            if (id != productoTerminado.Id)
            {
                return BadRequest();
            }

            _context.Entry(productoTerminado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoTerminadoExists(id))
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

        // POST: api/ProductoTerminadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoTerminado>> PostProductoTerminado(ProductoTerminado productoTerminado)
        {
            _context.ProductosTerminados.Add(productoTerminado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoTerminado", new { id = productoTerminado.Id }, productoTerminado);
        }

        // DELETE: api/ProductoTerminadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoTerminado(int id)
        {
            var productoTerminado = await _context.ProductosTerminados.FindAsync(id);
            if (productoTerminado == null)
            {
                return NotFound();
            }

            _context.ProductosTerminados.Remove(productoTerminado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoTerminadoExists(int id)
        {
            return _context.ProductosTerminados.Any(e => e.Id == id);
        }
    }
}
