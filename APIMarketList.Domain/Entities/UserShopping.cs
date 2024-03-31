using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class UserShopping : BaseEntity
    {
        public int ProductId { get; set; }
        public int ShoppingId { get; set; }

        public Product Product { get; set; }
        public Shopping Shopping { get; set; }
    }
}
