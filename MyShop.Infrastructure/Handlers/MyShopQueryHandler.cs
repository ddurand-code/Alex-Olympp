using MyShop.Domain.Ports.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Repositories;
using MyShop.Domain.Queries;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Infrastructure.Handlers
{
    public class MyShopQueryHandler : IQueryHandler<IEnumerable<ProductEntity>, GetAllProductsQuery>
    {
        private readonly IProductRepository _productRepository;
        public MyShopQueryHandler(IProductRepository productRepository)
        {
            Console.WriteLine("Get Product handle");
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductEntity>> HandleAsync(GetAllProductsQuery query, CancellationToken token = default)
        {
            var resultList = await _productRepository.GetProductOfferAsync();
            return resultList;
        }
    }
}
        