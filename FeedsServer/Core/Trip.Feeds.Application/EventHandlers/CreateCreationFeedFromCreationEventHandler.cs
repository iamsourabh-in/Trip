using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trip.Domain.Common.IntegrationEventModels;

namespace Trip.Feeds.Application.EventHandlers
{
    public class CreateCreationFeedFromCreationEventHandler : IRequestHandler<CreateCreationFeedFromCreationEvent>
    {
        public Task<Unit> Handle(CreateCreationFeedFromCreationEvent request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
