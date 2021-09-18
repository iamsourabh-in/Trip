using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trip.Creator.Application.Feature.Content.Queries.GetContent
{
    public class GetContentQueryHandler : IRequestHandler<GetContentQuery, GetContentQueryResponse>
    {
        public Task<GetContentQueryResponse> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
