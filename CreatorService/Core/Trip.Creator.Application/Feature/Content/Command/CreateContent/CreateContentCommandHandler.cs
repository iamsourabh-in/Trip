using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trip.Creator.Application.Feature.Content.Command.CreateContent
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommandRequest, CreateContentCommandResponse>
    {
        public async Task<CreateContentCommandResponse> Handle(CreateContentCommandRequest request, CancellationToken cancellationToken)
        {

            foreach (var formFile in request.files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Upload the files are create a path and save to db.
            // then add a queue to process this post. ProcessMemories Thumbnail Generation for three resolutions

            // Return
            throw new NotImplementedException();
        }
    }
}
