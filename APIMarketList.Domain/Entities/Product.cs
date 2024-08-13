using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ShoppingListItems = new HashSet<ShoppingListItem>();
        }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ShoppingListItem>? ShoppingListItems { get; set; }
    }
}
