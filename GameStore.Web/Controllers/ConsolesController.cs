using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Domain;
using GameStore.Persistence;

namespace GameStore.Web.Controllers
{
    public class ConsolesController : Controller
    {
        private readonly DataContext _context;

        public ConsolesController(DataContext context)
        {
            _context = context;
        }

        // GET: Consoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consoles.ToListAsync());
        }

        // GET: Consoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.Consoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            return View(gameConsole);
        }

        // GET: Consoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Manufacturer,Stock,TimesSold")] GameConsole gameConsole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameConsole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameConsole);
        }

        // GET: Consoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.Consoles.FindAsync(id);
            if (gameConsole == null)
            {
                return NotFound();
            }
            return View(gameConsole);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Manufacturer,Stock,TimesSold")] GameConsole gameConsole)
        {
            if (id != gameConsole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameConsole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameConsoleExists(gameConsole.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gameConsole);
        }

        // GET: Consoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.Consoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            return View(gameConsole);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameConsole = await _context.Consoles.FindAsync(id);
            if (gameConsole != null)
            {
                _context.Consoles.Remove(gameConsole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameConsoleExists(int id)
        {
            return _context.Consoles.Any(e => e.Id == id);
        }
    }
}
