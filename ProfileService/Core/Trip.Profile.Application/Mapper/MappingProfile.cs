﻿using Trip.Profile.Application.Feature.User.Command.AddUserCommand;
using Trip.Profile.Domain.Entities;

namespace Trip.Profile.Application.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserCommand, User>().ReverseMap();
        }
    }
}
