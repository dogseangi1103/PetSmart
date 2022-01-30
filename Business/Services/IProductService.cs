using Data.Entities;

namespace Business.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}