using AutoMapper;

namespace CatalinaNetworks.DataBase
{
    public class DBUserMappingProfile : Profile
    {
        public DBUserMappingProfile()
        {
            CreateMap<Entities.User, Core.Models.User>().ReverseMap();
            CreateMap<Entities.Photos, Core.Models.Photos>().ReverseMap();
        }
    }
}
