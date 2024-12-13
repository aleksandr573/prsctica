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
    public class MarkKtsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarkKtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkKt>>> GetMarkKts()
        {
            return await _context.MarkKts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarkKt>> GetMarkKt(int id)
        {
            var markKt = await _context.MarkKts.FindAsync(id);

            if (markKt == null)
            {
                return NotFound();
            }

            return markKt;
        }

        [HttpPost]
        public async Task<ActionResult<MarkKt>> PostMarkKt(MarkKt markKt)
        {
            _context.MarkKts.Add(markKt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMarkKt), new { id = markKt.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarkKt(int id, MarkKt markKt)
        {
            if (id != markKt.Id)
            {
                return BadRequest();
            }

            _context.Entry(markKt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkKtExists(id))
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
        public async Task<IActionResult> DeleteMarkKt(int id)
        {
            var markKt = await _context.markKt.FindAsync(id);
            if (markKt == null)
            {
                return NotFound();
            }

            _context.MarkKts.Remove(markKt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarkKtExists(int id)
        {
            return _context.MarkKts.Any(e => e.Id == id);
        }
    }
}