using APIMarketList.Domain.DTO.Member;

namespace APIMarketList.Domain.DTO.ShoppingList
{
    public class ShoppingListDTO
    {
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
        public int Status { get; set; }
        public IList<MemberDTO>? Members { get; set; }
    }
}
