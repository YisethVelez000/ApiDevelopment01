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
    public class ComprasInsumoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComprasInsumoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ComprasInsumoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprasInsumo>>> GetComprasInsumos()
        {
            return await _context.ComprasInsumos.ToListAsync();
        }

        // GET: api/ComprasInsumoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComprasInsumo>> GetComprasInsumo(int id)
        {
            var comprasInsumo = await _context.ComprasInsumos.FindAsync(id);

            if (comprasInsumo == null)
            {
                return NotFound();
            }

            return comprasInsumo;
        }

        // PUT: api/ComprasInsumoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprasInsumo(int id, ComprasInsumo comprasInsumo)
        {
            if (id != comprasInsumo.Id)
            {
                return BadRequest();
            }

            _context.Entry(comprasInsumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprasInsumoExists(id))
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

        // POST: api/ComprasInsumoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComprasInsumo>> PostComprasInsumo(ComprasInsumo comprasInsumo)
        {
            _context.ComprasInsumos.Add(comprasInsumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComprasInsumo", new { id = comprasInsumo.Id }, comprasInsumo);
        }

        // DELETE: api/ComprasInsumoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprasInsumo(int id)
        {
            var comprasInsumo = await _context.ComprasInsumos.FindAsync(id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }

            _context.ComprasInsumos.Remove(comprasInsumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprasInsumoExists(int id)
        {
            return _context.ComprasInsumos.Any(e => e.Id == id);
        }
    }
}
