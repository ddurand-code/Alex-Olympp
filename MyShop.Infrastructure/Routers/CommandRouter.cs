using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Commands;
using MyShop.Domain.Ports.Commands;
using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Queries;

namespace MyShop.Infrastructure.Routers
{
    public class CommandRouter : ICommandRouter
    {
        private readonly IDictionary<Type, ICommandHandler> _commandHandlers;

        public CommandRouter()
        {
            _commandHandlers = new Dictionary<Type, ICommandHandler>();
        }
        public async Task<TResult> RouteAsync<TResult, TCommand>(ACommand<TResult, TCommand> command) where TCommand : ACommand<TResult, TCommand>
        {
            if (_commandHandlers.TryGetValue(command.CommandType, out var queryHandler))
                return await((ICommandHandler<TResult, TCommand>)queryHandler).HandleAsync((TCommand)command);
            throw new KeyNotFoundException();
        }

        public void AddCommandHandler<TCommand>(ICommandHandler handler) where TCommand : ACommand
        {
            _commandHandlers.Add(handler.GetSupportedQueryType<TCommand>(), handler);
        }
    }
}
