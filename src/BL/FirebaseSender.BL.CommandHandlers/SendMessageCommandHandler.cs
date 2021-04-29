using FirebaseSender.BL.Contracts.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FirebaseSender.BL.CommandHandlers
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {
        public Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
