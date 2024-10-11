namespace APIMarketList.Domain.DTO.ShoppingList
{
    public class ShoppingListSaveResponseDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
