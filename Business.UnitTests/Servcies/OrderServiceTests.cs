using Business.Enums;
using Business.Services;
using Data.Context;
using Data.Entities;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System;
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
        public List<OrderItem> orderItems { get; set; }

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<DogseandatabaseContext>();
            _orderService = new OrderService(_dbContext.Object);

            orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, ProductName = "b1", Price = 10 },
                new OrderItem { Id = 2, ProductName = "b2", Price = 20 },
                new OrderItem { Id = 3, ProductName = "b3", Price = 30 },
            };
            unpaidOrder = new Order
            {
                Id = 11,
                Address = "a1",
                Status = (int)OrderStatus.Unpaid,
                OrderItem = orderItems
            };
            paidOrder = new Order { Id = 12, Address = "a2", Status = (int)OrderStatus.Paid };
            deliveredOrder = new Order { Id = 13, Address = "a3", Status = (int)OrderStatus.Delievered };
            var orders = new List<Order> { unpaidOrder, paidOrder, deliveredOrder };
            _dbContext.Setup(ps => ps.Order).ReturnsDbSet(orders);
        }

        [Test]
        public async Task Pay_OrderIsUnpaid_OrderStatusChangeToPaid()
        {
            var result = await _orderService.Pay(unpaidOrder.Id);

            Assert.That(result.Status == (int)OrderStatus.Paid);
        }

        [Test]
        public void Pay_OrderStatusIsNotUnpaid_ThrowInvalidOperationException()
        {
            Assert.That(() => _orderService.Pay(paidOrder.Id), Throws.Exception.TypeOf<InvalidOperationException>());
            Assert.That(() => _orderService.Pay(deliveredOrder.Id), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public async Task CalculateOrderPrice_WhenCalled_ReturnSumOfOrderItemPrice()
        {
            var result = await _orderService.CalculateOrderPrice(unpaidOrder.Id);

            Assert.That(result == orderItems.Sum(oi => oi.Price));
        }
    }
}
