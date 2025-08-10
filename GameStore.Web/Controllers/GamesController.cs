using GameStore.Application;
using GameStore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GamesService _gamesService;

        public GamesController(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var games = await _gamesService.GetAll();
            return View(games);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _gamesService.GetById(id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone")] Game game)
        {
            if (ModelState.IsValid)
            {
                var createdGame = await _gamesService.Create(game);

                if (createdGame)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _gamesService.GetById(id);

            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedGame = await _gamesService.Update(game);

                if (updatedGame)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _gamesService.GetById(id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _gamesService.GetById(id);

            if (game != null)
            {

                await _gamesService.Remove(game);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            var game = _gamesService.GetById(id);
            return game != null;
        }
    }
}
