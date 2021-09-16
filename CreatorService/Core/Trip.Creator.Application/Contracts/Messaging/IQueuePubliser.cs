using System.Threading.Tasks;
using Trip.Domain.Common.Messaging.Creator;

namespace Trip.Creator.Application.Contracts.Messaging
{
    public interface IQueuePubliser
    {
        public Task InitiateCreationProcessing(InitiateProcessCreationEvent creation);
    }
}
