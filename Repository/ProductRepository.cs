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
        public async Task<IEnumerable<Product>> Get()
        {
            return await dbContext.Products.ToListAsync();
        }
    }
}
