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
    public class CatalogoProductoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CatalogoProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoProducto>>> GetcatalogoProductos()
        {
            return await _context.catalogoProductos.ToListAsync();
        }

        // GET: api/CatalogoProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoProducto>> GetCatalogoProducto(int id)
        {
            var catalogoProducto = await _context.catalogoProductos.FindAsync(id);

            if (catalogoProducto == null)
            {
                return NotFound();
            }

            return catalogoProducto;
        }

        // PUT: api/CatalogoProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoProducto(int id, CatalogoProducto catalogoProducto)
        {
            if (id != catalogoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoProductoExists(id))
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

        // POST: api/CatalogoProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogoProducto>> PostCatalogoProducto(CatalogoProducto catalogoProducto)
        {
            _context.catalogoProductos.Add(catalogoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogoProducto", new { id = catalogoProducto.Id }, catalogoProducto);
        }

        // DELETE: api/CatalogoProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoProducto(int id)
        {
            var catalogoProducto = await _context.catalogoProductos.FindAsync(id);
            if (catalogoProducto == null)
            {
                return NotFound();
            }

            _context.catalogoProductos.Remove(catalogoProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogoProductoExists(int id)
        {
            return _context.catalogoProductos.Any(e => e.Id == id);
        }
    }
}
