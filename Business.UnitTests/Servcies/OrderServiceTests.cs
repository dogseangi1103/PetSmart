using Business.Services;
using Data.Context;
using Data.Entities;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.UnitTests.Servcies
{
    public class OrderServiceTests
    {
        private Mock<DogseandatabaseContext> _dbContext;
        private IOrderService _orderService;

        public Order unpaidOrder { get; set; }
        public Order paidOrder { get; set; }
        public Order deliveredOrder { get; set; }

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<DogseandatabaseContext>();
            _orderService = new OrderService(_dbContext.Object);

            // Todo: Status Enum
            unpaidOrder = new Order { Id = 11, Address = "a1", Status = 1 };
            paidOrder = new Order { Id = 12, Address = "a2", Status = 2 };
            deliveredOrder = new Order { Id = 13, Address = "a3", Status = 3 };
            var orders = new List<Order> { unpaidOrder, paidOrder, deliveredOrder };
            _dbContext.Setup(ps => ps.Order).ReturnsDbSet(orders);
        }

        [Test]
        public async Task Pay_OrderIsUnpaid_OrderStatusChangeToPaid()
        {
            var result = await _orderService.Pay(unpaidOrder.Id);

            // Todo: Status Enum
            Assert.That(result.Status == 2);
        }
    }
}
