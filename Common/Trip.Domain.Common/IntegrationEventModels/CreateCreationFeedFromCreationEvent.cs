using Trip.Domain.Common.Messaging;

namespace Trip.Domain.Common.IntegrationEventModels
{
    public class CreateCreationFeedFromCreationEvent : BaseCompletedEvent
    {
        public string CreationId { get; set; }
    }
}
