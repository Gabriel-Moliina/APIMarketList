using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Entities;
using AutoMapper;

namespace APIMarketList.Domain.Mappers
{
    public class MapperShoppingListItem : Profile
    {
        public MapperShoppingListItem()
        {
            CreateMap<ShoppingListItemSaveDTO, ShoppingListItem>();
        }
    }
}
