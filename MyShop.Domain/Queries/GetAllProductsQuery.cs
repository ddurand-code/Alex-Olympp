using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Ports.Queries;

namespace MyShop.Domain.Queries
{
    public class GetAllProductsQuery : AQuery<IEnumerable<ProductEntity>, GetAllProductsQuery>
    {
        public override async Task<IEnumerable<ProductEntity>> QueryAsync(IQueryRouter queryRouter)
        {
            return await queryRouter.RouteAsync(this);
        }
    }
}
