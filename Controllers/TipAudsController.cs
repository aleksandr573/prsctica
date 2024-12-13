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
    public class TipAudsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipAudsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipAud>>> GetTipAuds()
        {
            return await _context.TipAuds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipAud>> GetTipAud(int id)
        {
            var tipAud = await _context.TipAuds.FindAsync(id);

            if (tipAud == null)
            {
                return NotFound();
            }

            return tipAud;
        }

        [HttpPost]
        public async Task<ActionResult<TipAud>> PosttipAud(TipAud tipAud)
        {
            _context.TipAuds.Add(tipAud);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipAud), new { id = tipAud.Id }, tipAud);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipAud(int id, TipAud tipAud)
        {
            if (id != tipAud.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipAud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipAudExists(id))
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
        public async Task<IActionResult> DeleteTipAud(int id)
        {
            var tipAud = await _context.TipAud.FindAsync(id);
            if (tipAud == null)
            {
                return NotFound();
            }

            _context.TipAuds.Remove(tipAud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipAudExists(int id)
        {
            return _context.TipAuds.Any(e => e.Id == id);
        }
    }
}