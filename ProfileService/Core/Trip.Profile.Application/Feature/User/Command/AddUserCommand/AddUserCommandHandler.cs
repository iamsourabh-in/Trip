using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Trip.Profile.Application.Contracts.Persistance;

namespace Trip.Profile.Application.Feature.User.Command.AddUserCommand
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommandResponse>
    {
        private readonly IUserWriterRepository _userWriterRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserWriterRepository userWriterRepository, IMapper mapper)
        {
            _userWriterRepository = userWriterRepository;
            _mapper = mapper;
        }
        public async Task<AddUserCommandResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _userWriterRepository.SaveAsync(_mapper.Map<Trip.Profile.Domain.Entities.User>(request));

            return new AddUserCommandResponse() { Id = 1 };
        }
    }
}
