using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class ShoppingList : BaseEntity
    {
        public ShoppingList()
        {
            ShoppingListItens = new HashSet<ShoppingListItem>();
        }
        public string? Description { get; set; }
        public DateTime ListDate { get; set; }  
        public int GroupId { get; set; }
        public int Status { get; set; }

        public virtual Group? Group { get; set; }
        public ICollection<ShoppingListItem> ShoppingListItens { get; set; }
    }
}
