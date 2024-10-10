namespace APIMarketList.Domain.DTO.ShoppingListItem
{
    public class ShoppingListItemSaveDTO
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amout { get; set; }
        public int ShoppingListId { get; set; }
    }
}
