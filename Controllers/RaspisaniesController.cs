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
    public class RaspisaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RaspisaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raspisanie>>> GetRaspisanies()
        {
            return await _context.Raspisanies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Raspisanie>> GetRaspisanie(int id)
        {
            var raspisanie = await _context.Raspisanies.FindAsync(id);

            if (raspisanie == null)
            {
                return NotFound();
            }

            return raspisanie;
        }

        [HttpPost]
        public async Task<ActionResult<Raspisanie>> PostRaspisanie(Raspisanie raspisanie)
        {
            _context.Raspisanies.Add(raspisanie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaspisanie), new { id = raspisanie.Id }, raspisanie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaspisanie(int id, Raspisanie raspisanie)
        {
            if (id != raspisanie.Id)
            {
                return BadRequest();
            }

            _context.Entry(raspisanie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaspisanieExists(id))
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
        public async Task<IActionResult> DeleteRaspisanie(int id)
        {
            var raspisanie = await _context.Raspisanie.FindAsync(id);
            if (raspisanie == null)
            {
                return NotFound();
            }

            _context.Raspisanies.Remove(raspisanie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaspisanieExists(int id)
        {
            return _context.Raspisanies.Any(e => e.Id == id);
        }
    }
}