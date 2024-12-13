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
    public class AuditorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuditorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auditor>>> GetAuditors()
        {
            return await _context.Auditors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Auditor>> GetAuditor(int id)
        {
            var auditor = await _context.Auditors.FindAsync(id);

            if (auditor == null)
            {
                return NotFound();
            }

            return auditor;
        }

        [HttpPost]
        public async Task<ActionResult<Auditor>> PostAuditor(Auditor auditor)
        {
            _context.Auditors.Add(auditor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuditor), new { id = auditor.Id }, auditor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditor(int id, Auditor auditor)
        {
            if (id != auditor.Id)
            {
                return BadRequest();
            }

            _context.Entry(auditor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditorExists(id))
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
        public async Task<IActionResult> DeleteAuditor(int id)
        {
            var auditor = await _context.Auditor.FindAsync(id);
            if (auditor == null)
            {
                return NotFound();
            }

            _context.Auditors.Remove(auditor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditorExists(int id)
        {
            return _context.Auditors.Any(e => e.Id == id);
        }
    }
}