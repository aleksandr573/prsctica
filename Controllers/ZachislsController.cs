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
    public class ZachislsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZachislsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zachisl>>> GetZachisls()
        {
            return await _context.Zachisls.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zachisl>> GetZachisl(int id)
        {
            var zachisl = await _context.Zachisls.FindAsync(id);

            if (zachisl == null)
            {
                return NotFound();
            }

            return zachisl;
        }

        [HttpPost]
        public async Task<ActionResult<Zachisl>> PostZachisl(Zachisl zachisl)
        {
            _context.Zachisls.Add(zachisl);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetZachisl), new { id = zachisl.Id }, zachisl);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutZachisl(int id, Zachisl zachisl)
        {
            if (id != zachisl.Id)
            {
                return BadRequest();
            }

            _context.Entry(Zachisl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZachislExists(id))
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
        public async Task<IActionResult> DeleteZachisl(int id)
        {
            var zachisl = await _context.Zachisl.FindAsync(id);
            if (zachisl == null)
            {
                return NotFound();
            }

            _context.Zachisls.Remove(zachisl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZachislExists(int id)
        {
            return _context.Zachisls.Any(e => e.Id == id);
        }
    }
}