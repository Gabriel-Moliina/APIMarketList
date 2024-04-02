using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class Shopping : BaseEntity
    {
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ProductShopping> ProductShoppings { get; set; }
    }
}
