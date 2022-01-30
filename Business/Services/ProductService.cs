using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly DogseandatabaseContext _dbContext;

        public ProductService(DogseandatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts(string keyword = null)
        {
            var products = GetProductsNotDeleted();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.Name.Contains(keyword));
            }

            return await products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var products = GetProductsNotDeleted();
            var product = await products.SingleAsync(p => p.Id == id);
            return product;
        }

        private IQueryable<Product> GetProductsNotDeleted()
        {
            var products = _dbContext.Product.Where(p => p.IsDeleted == false);
            return products;
        }
    }
}
