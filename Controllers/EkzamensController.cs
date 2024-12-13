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
    public class EkzamensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EkzamensController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ekzamen>>> GetEkzamens()
        {
            return await _context.Ekzamens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ekzamen>> GetEkzamen(int id)
        {
            var ekzamen = await _context.Ekzamens.FindAsync(id);

            if (ekzamen == null)
            {
                return NotFound();
            }

            return ekzamen;
        }

        [HttpPost]
        public async Task<ActionResult<Ekzamen>> PostEkzamen(Ekzamen ekzamen)
        {
            _context.Ekzamens.Add(ekzamen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEkzamen), new { id = ekzamen.Id }, ekzamen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEkzamen(int id, Ekzamen ekzamen)
        {
            if (id != ekzamen.Id)
            {
                return BadRequest();
            }

            _context.Entry(ekzamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EkzamenExists(id))
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
        public async Task<IActionResult> DeleteEkzamen(int id)
        {
            var ekzamen = await _context.Ekzamen.FindAsync(id);
            if (ekzamen == null)
            {
                return NotFound();
            }

            _context.Ekzamens.Remove(ekzamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EkzamenExists(int id)
        {
            return _context.Ekzamens.Any(e => e.Id == id);
        }
    }
}