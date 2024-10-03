using APIMarketList.Domain.DTO.Product;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using AutoMapper;

namespace APIMarketList.Domain.Mappers
{
    public class MapperShoppingList : Profile
    {
        public MapperShoppingList()
        {
            CreateMap<ShoppingListSaveDTO, ShoppingList>();
        }
    }
}
