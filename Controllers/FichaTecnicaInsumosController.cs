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
    public class FichaTecnicaInsumosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FichaTecnicaInsumosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FichaTecnicaInsumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FichaTecnicaInsumos>>> GetFichasTecnicasInsumos()
        {
            return await _context.FichasTecnicasInsumos.ToListAsync();
        }

        // GET: api/FichaTecnicaInsumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FichaTecnicaInsumos>> GetFichaTecnicaInsumos(int id)
        {
            var fichaTecnicaInsumos = await _context.FichasTecnicasInsumos.FindAsync(id);

            if (fichaTecnicaInsumos == null)
            {
                return NotFound();
            }

            return fichaTecnicaInsumos;
        }

        // PUT: api/FichaTecnicaInsumos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFichaTecnicaInsumos(int id, FichaTecnicaInsumos fichaTecnicaInsumos)
        {
            if (id != fichaTecnicaInsumos.Id)
            {
                return BadRequest();
            }

            _context.Entry(fichaTecnicaInsumos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaTecnicaInsumosExists(id))
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

        // POST: api/FichaTecnicaInsumos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FichaTecnicaInsumos>> PostFichaTecnicaInsumos(FichaTecnicaInsumos fichaTecnicaInsumos)
        {
            _context.FichasTecnicasInsumos.Add(fichaTecnicaInsumos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFichaTecnicaInsumos", new { id = fichaTecnicaInsumos.Id }, fichaTecnicaInsumos);
        }

        // DELETE: api/FichaTecnicaInsumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFichaTecnicaInsumos(int id)
        {
            var fichaTecnicaInsumos = await _context.FichasTecnicasInsumos.FindAsync(id);
            if (fichaTecnicaInsumos == null)
            {
                return NotFound();
            }

            _context.FichasTecnicasInsumos.Remove(fichaTecnicaInsumos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FichaTecnicaInsumosExists(int id)
        {
            return _context.FichasTecnicasInsumos.Any(e => e.Id == id);
        }
    }
}
