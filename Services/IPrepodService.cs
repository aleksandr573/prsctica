// Services/IPrepodService.cs

using MyRestApi.Data;
using MyRestApi.Models;
using Microsoft.EntityFrameworkCore;



namespace MyRestApi.Services
{
    public interface IPrepodService
    {
        Task<IEnumerable<Prepod>> GetAllPrepodsAsync();
        Task<Prepod> GetPrepodByIdAsync(int id);
        Task<Prepod> AddPrepodAsync(Prepod prepod);
        Task UpdatePrepodAsync(int id, Prepod prepod);
        Task DeletePrepodAsync(int id);
    }
}

// Services/PrepodService.cs


namespace MyRestApi.Services
{
    public class PrepodService : IPrepodService
    {
        private readonly ApplicationDbContext _context;

        public PrepodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prepod>> GetAllPrepodsAsync()
        {
            return await _context.Prepods.ToListAsync();
        }

        public async Task<Prepod> GetPrepodByIdAsync(int id)
        {
            return await _context.Prepods.FindAsync(id);
        }

        public async Task<Prepod> AddPrepodAsync(Prepod prepod)
        {
            _context.Prepods.Add(prepod);
            await _context.SaveChangesAsync();
            return prepod;
        }

        public async Task UpdatePrepodAsync(int id, Prepod prepod)
        {
            var existingPrepod = await _context.Prepods.FindAsync(id);
            if (existingPrepod == null)
            {
                throw new KeyNotFoundException("Prepod not found");
            }

            existingPrepod.Name = prepod.Name;
            existingPrepod.Surname = prepod.Surname;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePrepodAsync(int id)
        {
            var prepod = await _context.Prepods.FindAsync(id);
            if (prepod == null)
            {
                throw new KeyNotFoundException("Prepod not found");
            }

            _context.Prepods.Remove(prepod);
            await _context.SaveChangesAsync();
        }
    }
}