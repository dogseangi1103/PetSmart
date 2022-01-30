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
        private const string Keyword = "成犬";

        private Mock<DogseandatabaseContext> _dbContext;
        private IProductService _productService;

        public Product productWithKeyword1 { get; set; }
        public Product productDeleted { get; set; }
        public Product productWithKeyword2 { get; set; }
        public Product productWithoutKeyword { get; set; }

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<DogseandatabaseContext>();
            _productService = new ProductService(_dbContext.Object);

            productWithKeyword1 = new Product { Id = 1, Name = "【法國皇家】中型成犬MA 15KG", IsDeleted = false };
            productDeleted = new Product { Id = 2, Name = "【法國皇家】大型成犬MXA 15KG", IsDeleted = true };
            productWithKeyword2 = new Product { Id = 3, Name = "Hill’s 希爾思™寵物食品 成犬 小顆粒 雞肉與大麥 12公斤", IsDeleted = false };
            productWithoutKeyword = new Product { Id = 4, Name = "Hill’s 希爾思™寵物食品 幼犬 小顆粒 雞肉與大麥 12公斤", IsDeleted = false };
            var products = new List<Product> { productWithKeyword1, productDeleted, productWithKeyword2, productWithoutKeyword };
            _dbContext.Setup(ps => ps.Product).ReturnsDbSet(products);
        }

        [Test]
        public void GetProducts_NoSearchFilter_ReturnProductsWhichAreNotDeleted()
        {
            var result = _productService.GetProducts();

            Assert.That(result.Contains(productWithKeyword1));
            Assert.That(result.Contains(productWithKeyword2));
            Assert.That(result.Contains(productWithoutKeyword));
            Assert.That(!result.Contains(productDeleted));
        }

        [Test]
        public void GetProducts_SearchKeyword_ReturnProductsNameWithKeyword()
        {
            var result = _productService.GetProducts(Keyword);

            Assert.That(result.Contains(productWithKeyword1));
            Assert.That(result.Contains(productWithKeyword2));
            Assert.That(!result.Contains(productWithoutKeyword));
            Assert.That(!result.Contains(productDeleted));
        }
    }
}
