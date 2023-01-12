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
    public class MyShopCommandHandler : ICommandHandler<OfferEntity, CreateOfferCommand>,
            ICommandHandler<OfferEntity, UpdateOfferCommand>
    {

        private readonly IWriteRepository _writeRepository;
        public MyShopCommandHandler(IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<OfferEntity> HandleAsync(CreateOfferCommand command, CancellationToken token = default)
        {
            Console.WriteLine("Save offer handle");
            var res = await _writeRepository.CreateOfferAsync(command.offer);
            return res;
        }

        public async Task<OfferEntity> HandleAsync(UpdateOfferCommand command, CancellationToken token = default)
        {
            Console.WriteLine("Update offer handle");
            var res = await _writeRepository.UpdateOfferAsync(command.Offer);
            return res;
        }
    }
}
