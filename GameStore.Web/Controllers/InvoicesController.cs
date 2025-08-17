using GameStore.Application.Services;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Web.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoicesService _invoicesService;
        private readonly CustomersService _customersService;
        private readonly InvoiceItemsService _invoiceItemsService;

        public InvoicesController(InvoicesService invoicesService, CustomersService customersService, InvoiceItemsService invoiceItemsService)
        {
            _invoicesService = invoicesService;
            _customersService = customersService;
            _invoiceItemsService = invoiceItemsService;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var invoices = await _invoicesService.GetByStatus("Open");
            return View(invoices);
        }

        public async Task<IActionResult> History()
        {
            var invoices = await _invoicesService.GetByStatus("Completed");
            return View(invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoicesService.GetByIdWithItemsAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public async Task<IActionResult> Create()
        {
            var customers = await _customersService.GetAll();
            ViewBag.Customers = new SelectList(customers, "Id", "FullName");
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

            var invoice = await _invoicesService.GetByIdWithItemsAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            var customers = await _customersService.GetAll();

            ViewBag.Customers = new SelectList(customers, "Id", "FullName");

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

        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _invoicesService.GetByIdWithItemsAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(int id)
        {
            var invoice = await _invoicesService.GetByIdWithItemsAsync(id);

            if (invoice != null)
            {

                await _invoicesService.Checkout(invoice);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
