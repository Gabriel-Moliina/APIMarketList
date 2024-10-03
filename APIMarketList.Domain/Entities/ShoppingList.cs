using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class ShoppingList : BaseEntity
    {
        public ShoppingList()
        {
            Members = new HashSet<Member>();
            ShoppingListItens = new HashSet<ShoppingListItem>();
        }
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }  
        public int Status { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<ShoppingListItem> ShoppingListItens { get; set; }
    }
}
