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
        private readonly ICreationResourceWriterRepository _creationResourceWriterRepository;
        private const string CloudPath = @"D:\Work\Trip\Trip\vCloud";
        private string MediumCloudPath = CloudPath + @"\medium";
        private string SmallCloudPath = CloudPath + @"\small";

        public InitiateProcessCreationEventHandler(
            IFileService fileService,
            ICreationReaderRepository creationReaderRepository,
            IMapper mapper,
            ICreationResourceReaderRepository creationResourceReaderRepository,
            ICreationResourceWriterRepository creationResourceWriterRepository)
        {
            _creationResourceWriterRepository = creationResourceWriterRepository;
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
                    if (FileProcessor.IsImage(resource.Path))
                    {
                        resource.MediumPath = await FileProcessor.GenerateThumbnail(new GenerateThumbnailRequest()
                        {
                            originalFullPath = resource.Path,
                            fileName = Path.GetFileName(resource.Path),
                            size = FileProcessorSizeEnum.Medium,
                            outputPath = MediumCloudPath

                        });
                        resource.SmallPath = await FileProcessor.GenerateThumbnail(new GenerateThumbnailRequest()
                        {
                            originalFullPath = resource.Path,
                            fileName = Path.GetFileName(resource.Path),
                            size = FileProcessorSizeEnum.Small,
                            outputPath = SmallCloudPath
                        });
                    }

                    if (FileProcessor.IsVideo(resource.Path))
                    {
                        resource.MediumPath = await FileProcessor.GenerateVideoThumbnail(new GenerateThumbnailRequest()
                        {
                            originalFullPath = resource.Path,
                            fileName = Path.GetFileName(resource.Path),
                            size = FileProcessorSizeEnum.Medium,
                            outputPath = MediumCloudPath
                        });
                        resource.SmallPath = await FileProcessor.GenerateVideoThumbnail(new GenerateThumbnailRequest()
                        {
                            originalFullPath = resource.Path,
                            fileName = Path.GetFileName(resource.Path),
                            size = FileProcessorSizeEnum.Small,
                            outputPath = SmallCloudPath
                        });
                    }

                    await _creationResourceWriterRepository.UpdateAsync(resource);
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
