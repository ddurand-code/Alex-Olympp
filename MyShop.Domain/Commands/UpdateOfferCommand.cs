using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Ports.Commands;

namespace MyShop.Domain.Commands
{
    public class UpdateOfferCommand : ACommand<OfferEntity, UpdateOfferCommand>
    {
        public OfferEntity Offer;

        public UpdateOfferCommand(OfferEntity offer)
        {
            Offer = offer;
        }
        public override async Task<OfferEntity> CommandAsync(ICommandRouter commandRouter)
        {
            return await commandRouter.RouteAsync(this);
        }
    }
}
