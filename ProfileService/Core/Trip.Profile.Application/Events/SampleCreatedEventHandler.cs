using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trip.Domain.Common.Messaging.Profile;

namespace Trip.Profile.Application.Events
{
    public class SampleCreatedEventHandler : IRequestHandler<SampleCreatedEvent>
    {
        public Task<Unit> Handle(SampleCreatedEvent request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
