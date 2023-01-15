using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Ports.Commands;

namespace MyShop.Domain.Commands
{
    public abstract class ACommand<TResult, TCommand> : ACommand
    {
        public Type CommandType => typeof(TCommand);

        public abstract Task<TResult> CommandAsync(ICommandRouter commandRouter);
    }
    public abstract class ACommand
    {
    }
}
