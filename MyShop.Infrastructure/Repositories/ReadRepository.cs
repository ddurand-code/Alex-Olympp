using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Ports.Repositories;
using MyShop.Endpoint.Models;
using MyShop.Endpoint.Ports;

namespace MyShop.Infrastructure.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private IDbContextFactory _dbContext;

        public ReadRepository(IDbContextFactory dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllOfferAsync()
        {
            await using var dbcontext = _dbContext.CreateDbContext();
            var productDb = await dbcontext.Products
                .Include(x => x.Quantity)
                .Include(x => x.Price)
                .ToListAsync();

            if (productDb.Count == 0)
                throw new EntityNotFoundException("No product found");

            var productEntity = productDb.Select(x =>
                new ProductEntity(x.Productid, x.Productname, x.Productbrand, x.Productsize, x.Quantity.Quantity, x.Price.Pricevalue));

            return productEntity;
        }
    }
}
