namespace Trip.Domain.Common.Messaging.Profile
{
    public class SampleCreatedEvent : BaseCompletedEvent
    {
        public string Result { get; set; }
    }
}
