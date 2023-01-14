using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Ports.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProductOfferAsync();
        Task<ProductEntity> CreateProductAsync(ProductEntity offerEntity);
        Task<ProductEntity> UpdateProductAsync(ProductEntity productEntity);
    }
}
