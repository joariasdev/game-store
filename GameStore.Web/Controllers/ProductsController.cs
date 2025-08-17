using GameStore.Application.Services;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetAllOrderedBySales();
            return View(products);
        }

        //// GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _productsService.GetById(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// GET: Products/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Products/Create     
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Game product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var createdGame = await _productsService.Create(product);

        //        if (createdGame)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _productsService.GetById(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Game product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var updatedGame = await _productsService.Update(product);

        //        if (updatedGame)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _productsService.GetById(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _productsService.GetById(id);

        //    if (product != null)
        //    {

        //        await _productsService.Remove(product);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GameExists(int id)
        //{
        //    var product = _productsService.GetById(id);
        //    return product != null;
        //}
    }
}
