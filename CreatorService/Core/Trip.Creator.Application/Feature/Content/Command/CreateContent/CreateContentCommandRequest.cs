using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Creator.Application.Feature.Content.Command.CreateContent
{
    public class CreateContentCommandRequest : IRequest<CreateContentCommandResponse>
    {
        public List<IFormFile> files { get; set; }

        public string Tagline { get; set; }

        public string Tags { get; set; }
    }
}
