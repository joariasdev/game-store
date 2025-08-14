using GameStore.Application.Services;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoicesService _invoicesService;

        public InvoicesController(InvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var invoices = await _invoicesService.GetAll();
            return View(invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoicesService.GetById(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                var createdInvoice = await _invoicesService.Create(invoice);

                if (createdInvoice)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoicesService.GetById(id);

            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedInvoice = await _invoicesService.Update(invoice);

                if (updatedInvoice)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoicesService.GetById(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _invoicesService.GetById(id);

            if (invoice != null)
            {

                await _invoicesService.Remove(invoice);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            var invoice = _invoicesService.GetById(id);
            return invoice != null;
        }
    }
}
