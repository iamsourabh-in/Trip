using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Application.Feature.Memories.Command.AddMemoriesCommand;
using Trip.Creator.Domain.Entities;

namespace Trip.Creator.Application.Mapper
{
	public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AddMemoriesCommandRequest, Creation>().ReverseMap();
        }
    }
}
