using Microsoft.EntityFrameworkCore;
using MultiTenancy.Data;
using MultiTenancy.Models;

namespace MultiTenancy.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Product> CreatedAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
    }
}
