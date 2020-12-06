using Domain.Core.Operations;
using MediatR;

namespace Domain.Core.Commands
{
    public class Command : IRequest<CommandResult>, IBaseRequest
    {
        
    }
}