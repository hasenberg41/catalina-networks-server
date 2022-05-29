using AutoMapper;

namespace CatalinaNetworks.API.Profiles
{
    internal class ApiUserMappingProfile : Profile
    {
        public ApiUserMappingProfile()
        {
            CreateMap<Core.Models.User, Models.User>().ReverseMap();
            CreateMap<Models.NewUser, Core.Models.User>();
        }
    }
}