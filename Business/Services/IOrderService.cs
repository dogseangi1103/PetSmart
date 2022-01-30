using Data.Entities;

namespace Business.Services
{
    public interface IOrderService
    {
        Task<Order> Pay(int id);
        Task<decimal> CalculateOrderPrice(int id);
    }
}