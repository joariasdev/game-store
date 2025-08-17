using GameStore.Application.Services;
using GameStore.Domain.Entities;
using GameStore.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersService _customersService;

        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _customersService.GetAll();
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customersService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var createdCustomer = await _customersService.Create(customer);

                if (createdCustomer)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customersService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedCustomer = await _customersService.Update(customer);

                if (updatedCustomer)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customersService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customersService.GetById(id);

            if (customer != null)
            {

                await _customersService.Remove(customer);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            var customer = _customersService.GetById(id);
            return customer != null;
        }
    }
}
