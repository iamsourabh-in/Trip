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
        private const string CloudPath = @"D:\Work\Trip\Trip\vCloud";
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
                    var ext = Path.GetExtension(formFile.FileName);
                    var newFileName = $"{Guid.NewGuid()}{ext}";

                    var content = formFile.ReadAsBytes();
                    var path = await _fileService.SaveFileAsync(CloudPath, newFileName, content);

                    var resource = new CreationResource();
                    resource.Path = path;
                    resource.MimeType = ext;
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

            return new CreateContentCommandResponse() { CreationId = creation.Id };
        }

        public void ValidateFiles(CreateContentCommandRequest request)
        {
            var filesize = 5;
            var supportedTypes = new[] { "jpg", "jpeg", "png", "mp4" };
            foreach (var file in request.files)
            {
                var fileExt = Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    throw new CreatorApplicationException($"File with name { file.FileName } is not Supported");

                }
                else if (file.Length > (filesize * 1024 * 1024))
                {
                    throw new CreatorApplicationException($"Max file size should be less than" + filesize + "MB");
                }
            }
        }
    }
}
