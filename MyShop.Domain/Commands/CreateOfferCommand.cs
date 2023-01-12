using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Commands;

namespace MyShop.Domain.Commands
{
    public class CreateOfferCommand : ACommand<OfferEntity, CreateOfferCommand>
    {
        public OfferEntity offer { get; }
        public CreateOfferCommand(OfferEntity offer)
        {
            this.offer = offer;
        }

        public override async Task<OfferEntity> CommandAsync(ICommandRouter commandRouter)
        {
            return await commandRouter.RouteAsync(this);
        }
    }
}
