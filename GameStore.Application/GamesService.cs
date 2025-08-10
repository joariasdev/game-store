
using GameStore.Domain;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application
{
    public class GamesService
    {
        private readonly DataContext _context;
        public GamesService(DataContext context)
        {
            _context = context;
        }

        // Get all games
        public async Task<List<Game>> GetAll()
        {
            return await _context.Games.ToListAsync();
        }

        // Get a game by id
        public async Task<Game?> GetById(int? id)
        {
            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);

            return game;
        }

        // Create a new game in database
        public async Task<bool> Create(Game game)
        {
            try
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Update an existing game in database
        public async Task<bool> Update(Game game)
        {
            try
            {

                _context.Update(game);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove one game from database
        public async Task<bool> Remove(Game game)
        {
            try
            {

                _context.Remove(game);
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
