using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService
    {
        private readonly DogseandatabaseContext _dbContext;

        public ProductService(DogseandatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _dbContext.Product;
            return products;
        }
    }
}
