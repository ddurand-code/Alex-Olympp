using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Repositories;

namespace MyShop.Infrastructure.Repositories
{
    public class WriteRepository : IWriteRepository
    {
        public async Task<OfferEntity> CreateOfferAsync(OfferEntity offerEntity)
        {
            Console.WriteLine("Save in database");
            return offerEntity;
        }

        public async Task<OfferEntity> UpdateOfferAsync(OfferEntity offerEntity)
        {

            Console.WriteLine("update in database");
            return offerEntity;
        }
    }
}
