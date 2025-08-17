using GameStore.Domain.Entities;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.Services
{
    public class ConsolesService
    {
        private readonly DataContext _context;
        public ConsolesService(DataContext context)
        {
            _context = context;
        }

        // Get all consoles
        public async Task<List<GameConsole>> GetAll()
        {
            return await _context.Consoles.ToListAsync();
        }

        // Get a console by id
        public async Task<GameConsole?> GetById(int? id)
        {
            var console = await _context.Consoles
                .FirstOrDefaultAsync(m => m.Id == id);

            return console;
        }

        // Create a new console in database
        public async Task<bool> Create(GameConsole console)
        {
            try
            {
                _context.Add(console);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Update an existing console in database
        public async Task<bool> Update(GameConsole console)
        {
            try
            {

                _context.Update(console);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove one console from database
        public async Task<bool> Remove(GameConsole console)
        {
            try
            {

                _context.Remove(console);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
