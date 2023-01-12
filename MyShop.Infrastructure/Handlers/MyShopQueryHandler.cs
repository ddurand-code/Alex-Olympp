using MyShop.Domain.Ports.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Ports.Repositories;
using MyShop.Domain.Queries;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Infrastructure.Handlers
{
    public class MyShopQueryHandler : IQueryHandler<IEnumerable<OfferEntity>, GetAllOffersQuery>
    {
        private readonly IReadRepository _readRepository;
        public MyShopQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<OfferEntity>> HandleAsync(GetAllOffersQuery query, CancellationToken token = default)
        {
            //use repository
            var resultList = await _readRepository.GetAllOfferAsync();

            if (resultList.Count == 0)
            {
                throw new EntityNotFoundException("No offer was found.");
            }

            return resultList;
        }
    }
}
        