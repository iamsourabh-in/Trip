using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trip.Application.Common.FileManager;
using Trip.Application.Common.Helpers;
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
            try
            {
                var creationResource = await _creationResourceReaderRepository.GetByCreationIdAsync(request.CreationId);

                var creation = await _creationReaderRepository.GetByIdAsync(request.CreationId);

                foreach (var resource in creationResource)
                {
                    if (ImageProcessor.IsImage(resource.Path))
                    {
                        ImageProcessor.GenerateThumbnail(new GenerateThumbnailRequest()
                        {
                            originPath = resource.Path,
                            fileName = Path.GetFileName(resource.Path),
                            size = "medium"
                        });
                    }

                    if (ImageProcessor.IsVideo(resource.Path))
                    {
                        await ImageProcessor.GenerateVideoThumbnail(new GenerateThumbnailRequest()
                        {
                            originPath = resource.Path,
                            fileName = Path.GetFileName(resource.Path),
                            size = "medium"
                        });
                    }

                    // Read File , Mime Type 

                    // Based on Mime Type Generate the Thumbnail with small, medium, original.

                    // Add It to Users Feed and make this public for other to see of they follow him/her.

                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
