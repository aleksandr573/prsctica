// Controllers/PrepodsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyRestApi.Services;
using MyRestApi.Models;

namespace MyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrepodsController : ControllerBase
    {
        private readonly IPrepodService _prepodService;

        public PrepodsController(IPrepodService prepodService)
        {
            _prepodService = prepodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrepods()
        {
            var prepods = await _prepodService.GetAllPrepodsAsync();
            return Ok(prepods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrepod(int id)
        {
            var prepod = await _prepodService.GetPrepodByIdAsync(id);
            if (prepod == null)
            {
                return NotFound();
            }
            return Ok(prepod);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrepod([FromBody] Prepod prepod)
        {
            var addedPrepod = await _prepodService.AddPrepodAsync(prepod);
            return CreatedAtAction(nameof(GetPrepod), new { id = addedPrepod.Id }, addedPrepod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrepod(int id, [FromBody] Prepod prepod)
        {
            await _prepodService.UpdatePrepodAsync(id, prepod);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrepod(int id)
        {
            await _prepodService.DeletePrepodAsync(id);
            return NoContent();
        }
    }
}