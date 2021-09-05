using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Trip.Identity.Areas.Admin.Models;
using Trip.Identity.Areas.Admin.Models.ApiResources;
using Trip.Identity.Areas.Admin.Models.ApiScopes;
using Trip.Identity.Areas.Admin.Models.IdentityResource;
using Trip.Identity.Areas.Admin.Models.Roles;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<ClientViewModel, Client>().ReverseMap();
            CreateMap<IdentityResourceListViewModel, IdentityResource>().ReverseMap();
            CreateMap<ApiResourceListViewModel, ApiResource>().ReverseMap();
            CreateMap<ApiScopeListViewModel, ApiScope>().ReverseMap();
            CreateMap<RoleListViewModel, IdentityRole>().ReverseMap();

        }

    }
}
