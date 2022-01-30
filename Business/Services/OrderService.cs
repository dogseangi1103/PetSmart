using Business.Enums;
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
    public class OrderService : IOrderService
    {
        private readonly DogseandatabaseContext _dbContext;

        public OrderService(DogseandatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> CalculateOrderPrice(int id)
        {
            var order = await _dbContext.Order
                .Include(o => o.OrderItem)
                .SingleAsync(o => o.Id == id);
            var orderPrice = order.OrderItem.Sum(oi => oi.Price);
            return orderPrice;
        }

        public async Task<Order> Pay(int id)
        {
            var order = await _dbContext.Order.SingleAsync(o => o.Id == id);

            if (order.Status != (int)OrderStatus.Unpaid)
            {
                throw new InvalidOperationException("訂單狀態不是未付款");
            }

            order.Status = (int)OrderStatus.Paid;
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
