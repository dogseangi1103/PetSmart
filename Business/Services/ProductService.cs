using Data.Context;
using Data.Entities;
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

        public IEnumerable<Product> GetProducts(string keyword = null)
        {
            var products = GetProductsNotDeleted();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.Name.Contains(keyword));
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            var products = GetProductsNotDeleted();
            var product = products.Single(p => p.Id == id);
            return product;
        }

        private IQueryable<Product> GetProductsNotDeleted()
        {
            var products = _dbContext.Product.Where(p => p.IsDeleted == false);
            return products;
        }
    }
}
