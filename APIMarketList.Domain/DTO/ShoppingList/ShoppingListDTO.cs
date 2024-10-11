using APIMarketList.Domain.DTO.Member;
using APIMarketList.Domain.DTO.ShoppingListItem;

namespace APIMarketList.Domain.DTO.ShoppingList
{
    public class ShoppingListDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
        public int Status { get; set; }
        public IList<MemberDTO>? Members { get; set; }
        public IList<ShoppingListItemDTO>? Itens { get; set; }
    }
}
