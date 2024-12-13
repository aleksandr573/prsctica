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
    public class PredmetPrepodsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PredmetPrepodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PredmetPrepod>>> GetPredmetPrepods()
        {
            return await _context.PredmetPrepods.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PredmetPrepod>> GetPredmetPrepod(int id)
        {
            var predmetprepod = await _context.PredmetPrepods.FindAsync(id);

            if (predmetprepod == null)
            {
                return NotFound();
            }

            return predmetprepod;
        }

        [HttpPost]
        public async Task<ActionResult<PredmetPrepod>> PostPredmetPrepod(PredmetPrepod predmetprepod)
        {
            _context.PredmetPrepods.Add(predmetprepod);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPredmetPrepod), new { id = predmetprepod.Id }, predmetprepod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredmetPrepod(int id, PredmetPrepod predmetprepod)
        {
            if (id != predmetprepod.Id)
            {
                return BadRequest();
            }

            _context.Entry(predmetprepod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredmetPrepodExists(id))
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
        public async Task<IActionResult> DeletePredmetPrepod(int id)
        {
            var predmetprepod = await _context.PredmetPrepods.FindAsync(id);
            if (predmetprepod == null)
            {
                return NotFound();
            }

            _context.PredmetPrepods.Remove(predmetprepod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PredmetPrepodExists(int id)
        {
            return _context.PredmetPrepods.Any(e => e.Id == id);
        }
    }
}