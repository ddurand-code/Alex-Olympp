using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Commands;
using MyShop.Domain.Queries;

namespace MyShop.Domain.Ports.Commands
{
    public interface ICommandHandler<TResult, TCommand> : ICommandHandler where TCommand : ACommand
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken token = default);
    }

    public interface ICommandHandler
    {
        public Type GetSupportedQueryType<TCommand>() where TCommand : ACommand => typeof(TCommand);
    }
}
