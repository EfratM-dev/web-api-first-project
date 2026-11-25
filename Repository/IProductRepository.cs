using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get(string? name, int? maxPrice, int? minPrice, string? desc, int?[] categoryIds);

        Task<Product> GetById(int id);
    }
}