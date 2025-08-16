using GameStore.Application.Services;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Web.Controllers
{
    public class InvoiceItemsController : Controller
    {
        private readonly InvoiceItemsService _invoiceItemsService;       
        private readonly ProductsService _productsService;

        public InvoiceItemsController(InvoiceItemsService invoiceItemsService, ProductsService productsService)
        {
            _invoiceItemsService = invoiceItemsService;            
            _productsService = productsService;
        }

        // GET: InvoiceItems
        public async Task<IActionResult> Index()
        {
            var invoiceItems = await _invoiceItemsService.GetAll();
            return View(invoiceItems);
        }

        // GET: InvoiceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _invoiceItemsService.GetById(id);

            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // GET: InvoiceItems/Create
        public async Task<IActionResult> Create(int invoiceId)
        {
            ViewBag.InvoiceId = invoiceId;
            var products = await _productsService.GetAll();
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View();
        }

        // POST: InvoiceItems/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceItem invoiceItem)
        {
            var product = await _productsService.GetById(invoiceItem.ProductId);
            invoiceItem.Price = product.Price;

            if (ModelState.IsValid)
            {
                var createdInvoiceItem = await _invoiceItemsService.Create(invoiceItem);

                if (createdInvoiceItem)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _invoiceItemsService.GetById(id);

            if (invoiceItem == null)
            {
                return NotFound();
            }
            return View(invoiceItem);
        }

        // POST: InvoiceItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedInvoiceItem = await _invoiceItemsService.Update(invoiceItem);

                if (updatedInvoiceItem)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _invoiceItemsService.GetById(id);

            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // POST: InvoiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceItem = await _invoiceItemsService.GetById(id);

            if (invoiceItem != null)
            {

                await _invoiceItemsService.Remove(invoiceItem);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceItemExists(int id)
        {
            var invoiceItem = _invoiceItemsService.GetById(id);
            return invoiceItem != null;
        }
    }
}
