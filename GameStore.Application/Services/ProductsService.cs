using GameStore.Domain.Entities;
using GameStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.Services
{
    public class ProductsService
    {
        private readonly DataContext _context;
        public ProductsService(DataContext context)
        {
            _context = context;
        }

        // Get all products
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllInStock()
        {
            return await _context.Products.Where(p => p.Stock > 0).ToListAsync();
        }

        public async Task<List<Product>> GetAllOrderedBySales()
        {
            return await _context.Products.Where(p => p.TimesSold > 0).OrderByDescending(p => p.TimesSold).ToListAsync();
        }

        // Get a product by id
        public async Task<Product?> GetById(int? id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            return product;
        }

        // Create a new product in database
        public async Task<bool> Create(Product product)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Update an existing product in database
        public async Task<bool> Update(Product product)
        {
            try
            {

                _context.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove one product from database
        public async Task<bool> Remove(Game product)
        {
            try
            {

                _context.Remove(product);
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
