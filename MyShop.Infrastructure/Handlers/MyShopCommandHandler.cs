using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Commands;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Commands;
using MyShop.Domain.Ports.Repositories;

namespace MyShop.Infrastructure.Handlers
{
    public class MyShopCommandHandler : ICommandHandler<ProductEntity, CreateProductCommand>,
            ICommandHandler<ProductEntity, UpdateProductCommand>
    {

        private readonly IWriteRepository _writeRepository;
        public MyShopCommandHandler(IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<ProductEntity> HandleAsync(CreateProductCommand command, CancellationToken token = default)
        {
            Console.WriteLine("Save Product handle");
            var res = await _writeRepository.CreateOfferAsync(command.Product);
            return res;
        }

        public async Task<ProductEntity> HandleAsync(UpdateProductCommand command, CancellationToken token = default)
        {
            Console.WriteLine("Update Product handle");
            var res = await _writeRepository.UpdateOfferAsync(command.Product);
            return res;
        }
    }
}
