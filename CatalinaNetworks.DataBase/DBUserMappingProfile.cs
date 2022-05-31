using AutoMapper;

namespace CatalinaNetworks.DataBase
{
    public class DBUserMappingProfile : Profile
    {
        public DBUserMappingProfile()
        {
            CreateMap<Entities.User, Core.Models.User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Core.Models.User, Entities.User>()
                .ForMember(u => u.Id, opt => opt.Ignore());

            CreateMap<Entities.Photos, Core.Models.Photos>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Core.Models.Photos, Entities.Photos>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
