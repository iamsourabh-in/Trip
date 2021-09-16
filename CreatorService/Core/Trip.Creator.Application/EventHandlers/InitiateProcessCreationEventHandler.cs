using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trip.Application.Common.FileManager;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Domain.Common.Messaging.Creator;

namespace Trip.Creator.Application.EventHandlers
{
    public class InitiateProcessCreationEventHandler : IRequestHandler<InitiateProcessCreationEvent>
    {

        private readonly IFileService _fileService;
        private readonly ICreationReaderRepository _creationReaderRepository;
        private readonly ICreationResourceReaderRepository _creationResourceReaderRepository;
        private readonly IMapper _mapper;

        public InitiateProcessCreationEventHandler(IFileService fileService, ICreationReaderRepository creationReaderRepository, IMapper mapper, ICreationResourceReaderRepository creationResourceReaderRepository)
        {
            _creationReaderRepository = creationReaderRepository;
            _mapper = mapper;
            _fileService = fileService;
            _creationResourceReaderRepository = creationResourceReaderRepository;
        }
        public async Task<Unit> Handle(InitiateProcessCreationEvent request, CancellationToken cancellationToken)
        {
            var creation = await _creationReaderRepository.GetByIdAsync(request.CreationId);

            return Unit.Value;
        }
    }
}
