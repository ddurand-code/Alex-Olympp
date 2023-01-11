using MyShop.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Ports.Queries
{
    public interface IQueryRouter
    {
        public Task<TResult> RouteAsync<TResult, TQuery>(AQuery<TResult, TQuery> query) where TQuery : AQuery<TResult, TQuery>;
    }
}
