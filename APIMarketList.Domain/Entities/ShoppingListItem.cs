﻿using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class ShoppingListItem : BaseEntity
    {
        public ShoppingListItem()
        {
        }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int Index { get; set; }
        public int ShoppingListId { get; set; }
        public virtual ShoppingList? ShoppingList { get; set; }
    }
}
