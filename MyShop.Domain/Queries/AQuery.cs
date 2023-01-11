using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Ports.Queries;

namespace MyShop.Domain.Queries
{
    public abstract class AQuery<TResult, TQuery> : AQuery
    {
        public Type QueryType => typeof(TQuery);

        public abstract Task<TResult> QueryAsync(IQueryRouter queryRouter);
    }

    public abstract class AQuery
    {

    }
}
