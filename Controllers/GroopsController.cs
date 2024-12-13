using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestApi.Data;
using MyRestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroopsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groop>>> GetGroops()
        {
            return await _context.Groops.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Groop>> GetGroop(int id)
        {
            var groop = await _context.Groop.FindAsync(id);

            if (groop == null)
            {
                return NotFound();
            }

            return groop;
        }

        [HttpPost]
        public async Task<ActionResult<Groop>> PostGroop(Groop groop)
        {
            _context.Groop.Add(groop);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroop), new { id = groop.Id }, groop);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroop(int id, Groop groop)
        {
            if (id != groop.Id)
            {
                return BadRequest();
            }

            _context.Entry(groop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroopExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroop(int id)
        {
            var groop = await _context.Groops.FindAsync(id);
            if (groop == null)
            {
                return NotFound();
            }

            _context.Groops.Remove(groop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroopExists(int id)
        {
            return _context.Groops.Any(e => e.Id == id);
        }
    }
}