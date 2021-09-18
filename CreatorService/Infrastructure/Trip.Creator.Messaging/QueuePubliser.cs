using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Application.Contracts.Messaging;
using Trip.Domain.Common;
using Trip.Domain.Common.IntegrationEventModels;
using Trip.Domain.Common.Messaging;
using Trip.Domain.Common.Messaging.Creator;

namespace Trip.Creator.Messaging
{
    public class QueuePubliser : IQueuePubliser
    {
        private readonly IBusPublisher _busPublisher;

        public QueuePubliser(IBusPublisher busPublisher)
        {

            _busPublisher = busPublisher;
        }

        public async Task CreateCreationFeedFromCreation(CreateCreationFeedFromCreationEvent creation)
        {
            await _busPublisher.PublishAsync<CreateCreationFeedFromCreationEvent>(IntegrationQueues.CreateCreationFeedFromCreationEventQueue, creation);
        }

        public async Task InitiateCreationProcessing(InitiateProcessCreationEvent creation)
        {
            await _busPublisher.PublishAsync<InitiateProcessCreationEvent>("InitiateProcessCreationEventQueue", creation);
        }
    }
}
