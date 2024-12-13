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
    public class KtsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kt>>> GetKts()
        {
            return await _context.Kts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kt>> GetKt(int id)
        {
            var kt = await _context.Kts.FindAsync(id);

            if (kt == null)
            {
                return NotFound();
            }

            return kt;
        }

        [HttpPost]
        public async Task<ActionResult<kt>> PostKt(Kt kt)
        {
            _context.Kts.Add(kt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKt), new { id = kt.Id }, kt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKt(int id, Kt kt)
        {
            if (id != kt.Id)
            {
                return BadRequest();
            }

            _context.Entry(kt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KtExists(id))
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
        public async Task<IActionResult> DeleteKt(int id)
        {
            var kt = await _context.Kt.FindAsync(id);
            if (kt == null)
            {
                return NotFound();
            }

            _context.Kts.Remove(kt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KtExists(int id)
        {
            return _context.Kts.Any(e => e.Id == id);
        }
    }
}