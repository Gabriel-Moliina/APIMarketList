using APIMarketList.Domain.DTO.Member;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using AutoMapper;

namespace APIMarketList.Domain.Mappers
{
    public class MapperMember : Profile
    {
        public MapperMember()
        {
            CreateMap<InviteMemberDTO, Member>();
            CreateMap<Member, MemberDTO>();
        }
    }
}
