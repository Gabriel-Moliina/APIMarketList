using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class ShoppingListItem : BaseEntity
    {
        public ShoppingListItem()
        {
            ShoppingPurchases = new HashSet<ShoppingPurchase>();
        }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ShoppingList? ShoppingList { get; set; }
        public virtual ICollection<ShoppingPurchase> ShoppingPurchases { get; set;}
    }
}
