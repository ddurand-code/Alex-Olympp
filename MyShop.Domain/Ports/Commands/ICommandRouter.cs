using MyShop.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Commands;

namespace MyShop.Domain.Ports.Commands
{
    public interface ICommandRouter
    {
        public Task<TResult> RouteAsync<TResult, TCommand>(ACommand<TResult, TCommand> command) where TCommand : ACommand<TResult, TCommand>;
    }
}
