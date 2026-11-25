using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get(string? name, int? maxPrice, int? minPrice, string? desc, int?[] categoryIds);
        Task<Product> GetById(int id);
    }
}