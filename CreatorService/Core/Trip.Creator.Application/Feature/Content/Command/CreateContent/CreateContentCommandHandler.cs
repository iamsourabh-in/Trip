using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trip.Application.Common.FileManager;
using Trip.Application.Common.Helpers;
using Trip.Creator.Application.Contracts.Messaging;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Application.Exceptions;
using Trip.Creator.Domain.Entities;
using Trip.Domain.Common.Messaging;
using Trip.Domain.Common.Messaging.Creator;

namespace Trip.Creator.Application.Feature.Content.Command.CreateContent
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommandRequest, CreateContentCommandResponse>
    {
        private readonly IFileService _fileService;
        private readonly ICreationWriterRepository _creationWriterRepository;
        private readonly ICreationResourceWriterRepository _creationResourceWriterRepository;
        private readonly IMapper _mapper;
        private readonly IQueuePubliser _busPublisher;

        public CreateContentCommandHandler(IFileService fileService, ICreationWriterRepository creationWriterRepository, IMapper mapper, IQueuePubliser busPublisher, ICreationResourceWriterRepository creationResourceWriterRepository)
        {
            _creationWriterRepository = creationWriterRepository;
            _mapper = mapper;
            _busPublisher = busPublisher;
            _fileService = fileService;
            _creationResourceWriterRepository = creationResourceWriterRepository;
        }

        public async Task<CreateContentCommandResponse> Handle(CreateContentCommandRequest request, CancellationToken cancellationToken)
        {
            ValidateFiles(request);
            var creationResource = new List<CreationResource>();
            foreach (var formFile in request.files)
            {
                if (formFile.Length > 0)
                {
                    var content = formFile.ReadAsBytes();
                    var path = await _fileService.SaveFileAsync(@"D:\Work\Trip\Trip\vCloud", formFile.FileName, content);

                    var resource = new CreationResource();
                    resource.Path = path;
                    resource.MimeType = Path.GetExtension(path);
                    creationResource.Add(resource);
                }
            }

            var creation = _mapper.Map<Creation>(request);
            await _creationWriterRepository.SaveAsync(creation);

            foreach (var item in creationResource)
            {
                item.Creation = creation;
                await _creationResourceWriterRepository.SaveAsync(item);
            }


            await _busPublisher.InitiateCreationProcessing(new InitiateProcessCreationEvent() { CreationId = creation.Id });
            // Upload the files are create a path and save to db.
            // then add a queue to process this post. ProcessMemories Thumbnail Generation for three resolutions

            // Return
            return new CreateContentCommandResponse();
        }

        public void ValidateFiles(CreateContentCommandRequest request)
        {
            var filesize = 5;
            var supportedTypes = new[] { "jpg", "jpeg", "mp4", "flv", "avi" };
            foreach (var file in request.files)
            {
                var fileExt = Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    throw new CreatorApplicationException($"{ file.FileName }File now Supported");
                   
                }
                else if (file.Length > (filesize * 1024 * 1024))
                {
                    throw new CreatorApplicationException($"Max file size should be less than" + filesize + "MB");
                }
            }
        }
    }
}
