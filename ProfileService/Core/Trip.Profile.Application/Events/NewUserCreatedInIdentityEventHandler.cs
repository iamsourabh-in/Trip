using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trip.Domain.Common.Messaging;
using Trip.Domain.Common.Messaging.Identity;
using Trip.Profile.Application.Feature.User.Command.AddUserCommand;

namespace Trip.Profile.Application.Events
{
    public class NewUserCreatedInIdentityEventHandler : IRequestHandler<NewUserCreatedInIdentityEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;

        public NewUserCreatedInIdentityEventHandler(IMediator mediator, IMapper mapper, IBusPublisher busPublisher)
        {
            this._mediator = mediator;
            this._mapper = mapper;
            this._busPublisher = busPublisher;
        }
        public async Task<Unit> Handle(NewUserCreatedInIdentityEvent request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AddUserCommand>(request);
            await _mediator.Send(user);
            return Unit.Value;

        }
    }
}
