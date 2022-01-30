using Data.Entities;

namespace Business.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(string keyword = null);
        Task<Product> GetProduct(int id);
    }
}