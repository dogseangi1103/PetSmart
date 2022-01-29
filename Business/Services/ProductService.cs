using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService
    {
        // Todo: strong type
        public IEnumerable<dynamic> GetProducts()
        {
            var products = new List<dynamic>
            {
                new { Id = 1, Name = "dog food 1" },
                new { Id = 2, Name = "dog food 2" },
                new { Id = 3, Name = "dog food 3" },
            };

            return products;
        }
    }
}
