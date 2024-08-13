using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class ShoppingPurchase : BaseEntity
    {
        public int QuantityPurchased { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long ShoppingListItemId { get; set; }
        public virtual ShoppingListItem? ShoppingListItem { get; set; }
    }
}
