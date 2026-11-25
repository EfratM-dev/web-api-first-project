using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        storeDBContext dbContext;
        public ProductRepository(storeDBContext storeDBContext)
        {
                this.dbContext = storeDBContext;
        }
        public async Task<IEnumerable<Product>> Get(string? name, int? maxPrice, int? minPrice, string? desc ,int?[] categoryIds)
        {
             return await dbContext.Products.Where(product =>
             (desc == null ? (true) : (product.Description.Contains(desc)))
             && (name == null ? (true) : (product.ProductName.Contains(name)))
             && ((minPrice == null) ? (true) : (product.Price >= minPrice))
             && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
             && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
             .OrderBy(product => product.Price).ToListAsync();

            //List<Product> products = await query.Skip((position - 1) * skip)
            //.Take(skip).Include(product => product.Category).ToListAsync();
            //var total = await query.CountAsync();
            //       (products, total);

        }

        public async Task<Product> GetById(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }
    }
}
