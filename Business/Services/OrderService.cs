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

        public async Task<Order> Pay(int id)
        {
            var order = await _dbContext.Order.SingleAsync(o => o.Id == id);
            order.Status = (int)OrderStatus.Paid;
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
