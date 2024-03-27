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
    public class EstampadoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstampadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Estampadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estampado>>> GetEstampados()
        {
            return await _context.Estampados.ToListAsync();
        }

        // GET: api/Estampadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estampado>> GetEstampado(int id)
        {
            var estampado = await _context.Estampados.FindAsync(id);

            if (estampado == null)
            {
                return NotFound();
            }

            return estampado;
        }

        // PUT: api/Estampadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstampado(int id, Estampado estampado)
        {
            if (id != estampado.Id)
            {
                return BadRequest();
            }

            _context.Entry(estampado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstampadoExists(id))
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

        // POST: api/Estampadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estampado>> PostEstampado(Estampado estampado)
        {
            _context.Estampados.Add(estampado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstampado", new { id = estampado.Id }, estampado);
        }

        // DELETE: api/Estampadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstampado(int id)
        {
            var estampado = await _context.Estampados.FindAsync(id);
            if (estampado == null)
            {
                return NotFound();
            }

            _context.Estampados.Remove(estampado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstampadoExists(int id)
        {
            return _context.Estampados.Any(e => e.Id == id);
        }
    }
}
