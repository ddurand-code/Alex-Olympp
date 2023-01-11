using MyShop.Domain.Ports.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Queries;

namespace MyShop.Infrastructure.Handlers
{
    public class MyShopQueryHandler : IQueryHandler<IEnumerable<OfferEntity>, GetAllOffersQuery>
    {
        public async Task<IEnumerable<OfferEntity>> HandleAsync(GetAllOffersQuery query, CancellationToken token = default)
        {
            //use repository
            var resultList = new List<OfferEntity>();

            resultList.Add(new OfferEntity(42));

            return resultList;
        }
    }
}
        