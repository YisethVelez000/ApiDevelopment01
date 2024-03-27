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
    public class EstampadoProductoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstampadoProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstampadoProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstampadoProducto>>> GetEstampadoProductos()
        {
            return await _context.EstampadoProductos.ToListAsync();
        }

        // GET: api/EstampadoProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstampadoProducto>> GetEstampadoProducto(int id)
        {
            var estampadoProducto = await _context.EstampadoProductos.FindAsync(id);

            if (estampadoProducto == null)
            {
                return NotFound();
            }

            return estampadoProducto;
        }

        // PUT: api/EstampadoProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstampadoProducto(int id, EstampadoProducto estampadoProducto)
        {
            if (id != estampadoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(estampadoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstampadoProductoExists(id))
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

        // POST: api/EstampadoProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstampadoProducto>> PostEstampadoProducto(EstampadoProducto estampadoProducto)
        {
            _context.EstampadoProductos.Add(estampadoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstampadoProducto", new { id = estampadoProducto.Id }, estampadoProducto);
        }

        // DELETE: api/EstampadoProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstampadoProducto(int id)
        {
            var estampadoProducto = await _context.EstampadoProductos.FindAsync(id);
            if (estampadoProducto == null)
            {
                return NotFound();
            }

            _context.EstampadoProductos.Remove(estampadoProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstampadoProductoExists(int id)
        {
            return _context.EstampadoProductos.Any(e => e.Id == id);
        }
    }
}
