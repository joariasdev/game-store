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
            return await _context.InvoiceItems.ToListAsync();
        }

        // Get a invoiceItem by id
        public async Task<InvoiceItem?> GetById(int? id)
        {
            var invoiceItem = await _context.InvoiceItems
                .FirstOrDefaultAsync(m => m.Id == id);

            return invoiceItem;
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
