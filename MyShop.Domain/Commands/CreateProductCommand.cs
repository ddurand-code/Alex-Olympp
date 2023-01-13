using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Commands;

namespace MyShop.Domain.Commands
{
    public class CreateProductCommand : ACommand<ProductEntity, CreateProductCommand>
    {
        public ProductEntity Product { get; }
        public CreateProductCommand(ProductEntity product)
        {
            this.Product = product;
        }

        public override async Task<ProductEntity> CommandAsync(ICommandRouter commandRouter)
        {
            return await commandRouter.RouteAsync(this);
        }
    }
}
