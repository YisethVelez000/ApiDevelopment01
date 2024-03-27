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
    public class FichaTecnicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FichaTecnicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FichaTecnicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FichaTecnica>>> GetFichasTecnicas()
        {
            return await _context.FichasTecnicas.ToListAsync();
        }

        // GET: api/FichaTecnicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FichaTecnica>> GetFichaTecnica(int id)
        {
            var fichaTecnica = await _context.FichasTecnicas.FindAsync(id);

            if (fichaTecnica == null)
            {
                return NotFound();
            }

            return fichaTecnica;
        }

        // PUT: api/FichaTecnicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFichaTecnica(int id, FichaTecnica fichaTecnica)
        {
            if (id != fichaTecnica.Id)
            {
                return BadRequest();
            }

            _context.Entry(fichaTecnica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaTecnicaExists(id))
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

        // POST: api/FichaTecnicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FichaTecnica>> PostFichaTecnica(FichaTecnica fichaTecnica)
        {
            _context.FichasTecnicas.Add(fichaTecnica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFichaTecnica", new { id = fichaTecnica.Id }, fichaTecnica);
        }

        // DELETE: api/FichaTecnicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFichaTecnica(int id)
        {
            var fichaTecnica = await _context.FichasTecnicas.FindAsync(id);
            if (fichaTecnica == null)
            {
                return NotFound();
            }

            _context.FichasTecnicas.Remove(fichaTecnica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FichaTecnicaExists(int id)
        {
            return _context.FichasTecnicas.Any(e => e.Id == id);
        }
    }
}
