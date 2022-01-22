using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Trip.Creator.Application.Feature.Content.Command.CreateContent;

namespace Trip.Creator.Application.Feature.Restaurant.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateContentCommandRequest, CreateContentCommandResponse>
    {
        public Task<CreateContentCommandResponse> Handle(CreateContentCommandRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
