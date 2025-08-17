using GameStore.Domain.Entities;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.Services
{
    public class CustomersService
    {
        private readonly DataContext _context;
        public CustomersService(DataContext context)
        {
            _context = context;
        }

        // Get all customers
        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        // Get a customer by id
        public async Task<Customer?> GetById(int? id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);

            return customer;
        }

        // Create a new customer in database
        public async Task<bool> Create(Customer customer)
        {
            try
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Update an existing customer in database
        public async Task<bool> Update(Customer customer)
        {
            try
            {

                _context.Update(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove one customer from database
        public async Task<bool> Remove(Customer customer)
        {
            try
            {

                _context.Remove(customer);
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
