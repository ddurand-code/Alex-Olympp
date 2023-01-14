using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Ports.Repositories;
using MyShop.Endpoint.Models;
using MyShop.Endpoint.Ports;
using Npgsql;
using MyShop.Endpoint;

namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IDbContextFactory _dbContext;
        private NpgDbConnectionProvider _npgDbConnectionProvider;

        public ProductRepository(IDbContextFactory dbContext, NpgDbConnectionProvider npgDbConnectionProvider)
        {
            _dbContext = dbContext;
            _npgDbConnectionProvider = npgDbConnectionProvider;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductOfferAsync()
        {
            var sql = @"select p.productid ,productname ,productbrand ,productsize, s.quantity ,p2.price  from product p
                        inner join price p2 on p2.productid = p.productid
                        inner join stock s ON s.productid = p.productid";

            await using var connection = _npgDbConnectionProvider.GetSqlConnection();

            var resultdb = await connection.QueryAsync<ProductEntity>(sql);
            var result = resultdb.ToList();
            if (result.Count == 0)
                throw new EntityNotFoundException("No product found");

            return result;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductOfferEFCOreAsync()
        {
            await using var dbcontext = _dbContext.CreateDbContext();
            var productDb = await dbcontext.Products
                .Include(x => x.Stock)
                .Include(x => x.Price)
                .ToListAsync();

            var connect = dbcontext.Database.GetDbConnection();

            new MyshopdbContext().Database.GetDbConnection();

            if (productDb.Count == 0)
                throw new EntityNotFoundException("No product found");

            var productEntity = productDb.Select(x =>
                new ProductEntity(x.Productid, x.Productname, x.Productbrand, x.Productsize, x.Stock.Quantity, x.Price.Pricevalue));

            return productEntity;
        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity productEntity)
        {
            var sql = @"with new_product as (
                    	insert into product (productname, productbrand, productsize)
                    	values (@ProductName, @ProductBrand, @ProductSize)
                    	returning productid
                    ),
                    
                     new_stock as (
                     insert into stock (productid, quantity)
                     values ( (select productid from new_product) , @Quantity)
                     returning productid
                     )
                    
                    insert into price  (productid, price)
                    values ( (select productid from new_stock) , @Price)";

            await using var connection = _npgDbConnectionProvider.GetSqlConnection();

            var rowResult = await connection.ExecuteAsync(sql, productEntity);
            if (rowResult == 0)
                throw new CreateFailureException($"Product {productEntity.ProductName} could not be created.");

            return productEntity;
        }

        public async Task<ProductEntity> CreateProductEFCoreAsync(ProductEntity productEntity)
        {
            await using var dbcontext = _dbContext.CreateDbContext();

            var productDb = new Product()
            {
                Productname = productEntity.ProductName,
                Productbrand = productEntity.ProductBrand,
                Productsize = productEntity.ProductSize,
                Stock = new Stock() { Quantity = productEntity.Quantity },
                //Price = new Price() { Pricevalue = productEntity.Price }
            };

            await dbcontext.AddAsync(productDb);
            await dbcontext.SaveChangesAsync();

            productEntity.ProductId = productDb.Productid;

            return productEntity;
        }

        public async Task<ProductEntity> UpdateProductAsync(ProductEntity productEntity)
        {
            var sql = @"with new_product as (
            	update product
            	set productname = @ProductName, productbrand = @ProductBrand, productsize = @ProductSize
            	where productid = @ProductId
            	returning productid
            ),
            
             new_stock as (
             update stock
             set quantity = @Quantity
             where productid = (select productid from new_product)
             returning productid
             )
            
            update price
            set price = @Price
            where productid = (select productid from new_stock)";

            await using var connection = _npgDbConnectionProvider.GetSqlConnection();

            var rowResult = await connection.ExecuteAsync(sql, productEntity);
            if (rowResult == 0)
                throw new DbUpdateException($"Product with id : {productEntity.ProductId} could not be modify.");

            return productEntity;
        }
    }
}
