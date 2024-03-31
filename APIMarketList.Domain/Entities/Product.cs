using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<UserShopping> UserShoppings { get; set; }
    }
}
