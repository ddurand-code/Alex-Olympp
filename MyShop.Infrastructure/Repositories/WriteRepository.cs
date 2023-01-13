using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Commands;
using MyShop.Domain.Entities;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Ports.Repositories;
using MyShop.Endpoint.Models;
using MyShop.Endpoint.Ports;

namespace MyShop.Infrastructure.Repositories
{
    public class WriteRepository : IWriteRepository
    {
        private IDbContextFactory _dbContext;

        public WriteRepository(IDbContextFactory dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductEntity> CreateOfferAsync(ProductEntity productEntity)
        {
            await using var dbcontext =  _dbContext.CreateDbContext();

            var productDb = new Product()
            {
                Productname = productEntity.ProductName,
                Productbrand = productEntity.ProductBrand,
                Productsize = productEntity.ProductSize,
                Quantity = new Stock(){Quantity = productEntity.Quantity},
                Price = new Price(){Pricevalue = productEntity.Price}
            };

            await dbcontext.AddAsync(productDb);
            await dbcontext.SaveChangesAsync();

            productEntity.ProductId = productDb.Productid;

            return productEntity;
        }

        public async Task<ProductEntity> UpdateOfferAsync(ProductEntity productEntity)
        {

            await using var dbcontext = _dbContext.CreateDbContext();

            var productDb = await dbcontext.Products
                .Include(x => x.Quantity)
                .Include(x => x.Price)
                .Where(x => x.Productid == productEntity.ProductId)
                .FirstOrDefaultAsync();

            if (productDb == null)
            {
                throw new EntityNotFoundException($"Product with id {productEntity.ProductId} was not found");
            }

            productDb.Productname = productEntity.ProductName;
            productDb.Productbrand = productEntity.ProductBrand;
            productDb.Productsize = productEntity.ProductSize;
            productDb.Quantity.Quantity = productEntity.Quantity;
            productDb.Price.Pricevalue = productEntity.Price;

            dbcontext.Update(productDb);
            await dbcontext.SaveChangesAsync();

            return productEntity;
        }
    }
}
