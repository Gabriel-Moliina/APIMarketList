namespace APIMarketList.Domain.DTO.ShoppingListItem
{
    public class ShoppingListItemSaveDTO
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ShoppingListId { get; set; }
    }
}
