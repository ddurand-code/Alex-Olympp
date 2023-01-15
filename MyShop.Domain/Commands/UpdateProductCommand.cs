using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Commands;

namespace MyShop.Domain.Commands
{
    public class UpdateProductCommand : ACommand<ProductEntity, UpdateProductCommand>
    {
        public ProductEntity Product;

        public UpdateProductCommand(ProductEntity product)
        {
            Product = product;
        }
        public override async Task<ProductEntity> CommandAsync(ICommandRouter commandRouter)
        {
            return await commandRouter.RouteAsync(this);
        }
    }
}
