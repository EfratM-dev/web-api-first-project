using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Get()
        {
            return await productRepository.Get();
        }
    }
}
