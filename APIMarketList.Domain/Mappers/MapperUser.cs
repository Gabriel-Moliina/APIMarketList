using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Entities;
using AutoMapper;

namespace APIMarketList.Domain.Mappers
{
    public class MapperUser : Profile
    {
        public MapperUser()
        {
            CreateMap<UserSaveDTO, User>();
            CreateMap<User, UserSaveResponseDTO>();
        }
    }
}
