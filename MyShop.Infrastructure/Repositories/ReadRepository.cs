using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Repositories;

namespace MyShop.Infrastructure.Repositories
{
    public class ReadRepository : IReadRepository
    {
        public async Task<List<OfferEntity>> GetAllOfferAsync()
        {
            return new List<OfferEntity>() { new (42, "test", "test", "L", 1,1) };
        }
    }
}
