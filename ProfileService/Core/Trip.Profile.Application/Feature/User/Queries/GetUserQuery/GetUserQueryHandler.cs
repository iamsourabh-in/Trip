using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Trip.Profile.Application.Contracts.Persistance;

namespace Trip.Profile.Application.Feature.User.Queries.GetUserQuery
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private readonly IUserReaderRepository _userReaderRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserReaderRepository userReaderRepository, IMapper mapper)
        {
            _userReaderRepository = userReaderRepository;
            _mapper = mapper;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userReaderRepository.GetAsync(_mapper.Map<Domain.Entities.User>(request));
            return _mapper.Map<GetUserQueryResponse>(user);

        }
    }
}
