using GameStore.Domain.Entities;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.Services
{
    public class InvoicesService
    {
        private readonly DataContext _context;
        public InvoicesService(DataContext context)
        {
            _context = context;
        }

        // Get all invoices
        public async Task<List<Invoice>> GetAll()
        {
            return await _context.Invoices.Include(i => i.Customer).Include(i => i.InvoiceItems).ToListAsync();
        }

        // Get a invoice by id
        public async Task<Invoice?> GetById(int? id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.InvoiceItems)
                .FirstOrDefaultAsync(m => m.Id == id);

            return invoice;
        }

        public async Task<Invoice?> GetByIdWithItemsAsync(int? id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.InvoiceItems)
                    .ThenInclude(ii => ii.Product)
                .FirstOrDefaultAsync(i => i.Id == id);

            return invoice;
        }

        // Create a new invoice in database
        public async Task<bool> Create(Invoice invoice)
        {
            try
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Update an existing invoice in database
        public async Task<bool> Update(Invoice invoice)
        {
            try
            {

                _context.Update(invoice);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove one invoice from database
        public async Task<bool> Remove(Invoice invoice)
        {
            try
            {

                _context.Remove(invoice);
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
