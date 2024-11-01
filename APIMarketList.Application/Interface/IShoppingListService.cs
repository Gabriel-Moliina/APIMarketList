﻿using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Service.Interface
{
    public interface IShoppingListService
    {
        Task<ShoppingListSaveResponseDTO> CreateNew(ShoppingListSaveDTO shoppingList);
        Task<ShoppingListDTO?> Get(int id);
        Task<IList<ShoppingListDTO>> GetAll();
        Task<IList<ShoppingListDTO>> GetByUser(int userId);
        Task Delete(int id);
    }
}
