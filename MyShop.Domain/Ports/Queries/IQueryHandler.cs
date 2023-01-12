using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Queries;

namespace MyShop.Domain.Ports.Queries
{
    public interface IQueryHandler<TResult, TQuery> : IQueryHandler where TQuery : AQuery
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken token = default);
    }

    public interface IQueryHandler
    {
        public Type GetSupportedQueryType<TQuery>() where TQuery : AQuery => typeof(TQuery);
    }
}
