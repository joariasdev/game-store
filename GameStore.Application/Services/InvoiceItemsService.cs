using GameStore.Domain.Entities;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.Services
{
    public class InvoiceItemsService
    {
        private readonly DataContext _context;
        public InvoiceItemsService(DataContext context)
        {
            _context = context;
        }

        // Get all invoiceItems
        public async Task<List<InvoiceItem>> GetAll()
        {
            return await _context.InvoiceItems.Include(i => i.Product).ToListAsync();
        }

        // Get a invoiceItem by id
        public async Task<InvoiceItem?> GetById(int? id)
        {
            var invoiceItem = await _context.InvoiceItems.Include(ii => ii.Invoice).Include(ii => ii.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            return invoiceItem;
        }

        public async Task<List<InvoiceItem>> GetByInvoiceId(int? id)
        {
            return await _context.InvoiceItems.Where(i => i.InvoiceId == id).Include(i => i.Product).ToListAsync();
        }

        // Create a new invoiceItem in database
        public async Task<bool> Create(InvoiceItem invoiceItem)
        {
            try
            {
                _context.Add(invoiceItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Update an existing invoiceItem in database
        public async Task<bool> Update(InvoiceItem invoiceItem)
        {
            try
            {

                _context.Update(invoiceItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove one invoiceItem from database
        public async Task<bool> Remove(InvoiceItem invoiceItem)
        {
            try
            {

                _context.Remove(invoiceItem);
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
