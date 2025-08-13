using GameStore.Application.Services;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controllers
{
    public class ConsolesController : Controller
    {
        private readonly ConsolesService _consolesService;

        public ConsolesController(ConsolesService consolesService)
        {
            _consolesService = consolesService;
        }

        // GET: Consoles
        public async Task<IActionResult> Index()
        {
            var consoles = await _consolesService.GetAll();
            return View(consoles);
        }

        // GET: Consoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _consolesService.GetById(id);

            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // GET: Consoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consoles/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone")] GameConsole console)
        {
            if (ModelState.IsValid)
            {
                var createdConsole = await _consolesService.Create(console);

                if (createdConsole)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(console);
        }

        // GET: Consoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _consolesService.GetById(id);

            if (console == null)
            {
                return NotFound();
            }
            return View(console);
        }

        // POST: Consoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone")] GameConsole console)
        {
            if (id != console.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedConsole = await _consolesService.Update(console);

                if (updatedConsole)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(console);
        }

        // GET: Consoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _consolesService.GetById(id);

            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var console = await _consolesService.GetById(id);

            if (console != null)
            {

                await _consolesService.Remove(console);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ConsoleExists(int id)
        {
            var console = _consolesService.GetById(id);
            return console != null;
        }
    }
}
