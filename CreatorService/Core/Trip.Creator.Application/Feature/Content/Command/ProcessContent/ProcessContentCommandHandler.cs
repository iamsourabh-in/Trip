using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trip.Creator.Application.Feature.Content.Command.ProcessContent
{
    public class ProcessContentCommandHandler : IRequestHandler<ProcessContentCommandRequest, ProcessContentCommandResponse>
    {
        public Task<ProcessContentCommandResponse> Handle(ProcessContentCommandRequest request, CancellationToken cancellationToken)
        {

            // Upload the files are create a path and save to db.
            // then add a queue to process this post. ProcessMemories Thumbnail Generation for three resolutions
           
            // Return
            throw new NotImplementedException();
        }
    }
}
