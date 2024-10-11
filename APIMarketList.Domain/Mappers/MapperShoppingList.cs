using APIMarketList.Domain.DTO.Member;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Entities;
using AutoMapper;

namespace APIMarketList.Domain.Mappers
{
    public class MapperShoppingList : Profile
    {
        public MapperShoppingList()
        {
            CreateMap<Member, MemberDTO>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.User.Name))
                .ForMember(x => x.Email, y => y.MapFrom(x => x.User.Email));
            CreateMap<ShoppingListItem, ShoppingListItemDTO>();
            CreateMap<ShoppingListSaveDTO, ShoppingList>();
            CreateMap<ShoppingList, ShoppingListDTO>()
                .ForMember(x => x.Itens, y => y.MapFrom(x => x.ShoppingListItens));
            CreateMap<ShoppingList, ShoppingListSaveResponseDTO>();
        }
    }
}
