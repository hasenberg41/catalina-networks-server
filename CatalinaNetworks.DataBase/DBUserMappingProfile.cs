using AutoMapper;

namespace CatalinaNetworks.DataBase
{
    public class DBUserMappingProfile : Profile
    {
        public DBUserMappingProfile()
        {
            CreateMap<Entities.Photos, Core.Models.User>().ReverseMap();
        }
    }
}
