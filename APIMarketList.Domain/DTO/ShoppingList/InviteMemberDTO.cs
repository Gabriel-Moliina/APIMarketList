namespace APIMarketList.Domain.DTO.ShoppingList
{
    public class InviteMemberDTO
    {
        public int ShoppingListId { get; set; }
        public bool CanUpdate { get; set; }
        public string? MemberEmail { get; set; }
    }
}
