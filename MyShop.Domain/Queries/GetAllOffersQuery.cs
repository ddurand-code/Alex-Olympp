using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Ports.Queries;

namespace MyShop.Domain.Queries
{
    public class GetAllOffersQuery : AQuery<IEnumerable<OfferEntity>, GetAllOffersQuery>
    {
        public override async Task<IEnumerable<OfferEntity>> QueryAsync(IQueryRouter queryRouter)
        {
            return await queryRouter.RouteAsync(this);
        }
    }
}
