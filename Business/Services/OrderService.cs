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

        public Task<Order> Pay(int id)
        {
            throw new NotImplementedException();
        }
    }
}
