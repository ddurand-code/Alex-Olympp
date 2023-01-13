using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Ports.Repositories
{
    public interface IWriteRepository
    {
        Task<ProductEntity> CreateOfferAsync(ProductEntity offerEntity);
        Task<ProductEntity> UpdateOfferAsync(ProductEntity productEntity);
    }
}
