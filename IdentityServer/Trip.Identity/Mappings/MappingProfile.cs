using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Trip.Identity.Areas.Admin.Models;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<ClientViewModel, Client>().ReverseMap();
        }
          
    }
}
