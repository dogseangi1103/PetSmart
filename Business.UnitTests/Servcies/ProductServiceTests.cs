using Business.Services;
using Data.Context;
using Data.Entities;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Business.UnitTests.Servcies
{
    public class ProductServiceTests
    {
        private Mock<DogseandatabaseContext> _dbContext;
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<DogseandatabaseContext>();
            _productService = new ProductService(_dbContext.Object);
        }

        [Test]
        public void GetProducts_WhenCalled_ReturnProductsWhichAreNotDeleted()
        {
            var product1 = new Product { Id = 1, Name = "a1", IsDeleted = false };
            var product2 = new Product { Id = 2, Name = "a2", IsDeleted = true };
            var product3 = new Product { Id = 3, Name = "a3", IsDeleted = false };
            var products = new List<Product> { product1, product2, product3 };
            _dbContext.Setup(ps => ps.Product).ReturnsDbSet(products);

            var result = _productService.GetProducts();

            Assert.That(!result.Contains(product2));
        }
    }
}
