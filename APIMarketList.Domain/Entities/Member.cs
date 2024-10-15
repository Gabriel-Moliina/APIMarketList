using APIMarketList.Domain.Entities.Base;
using System.Data;

namespace APIMarketList.Domain.Entities
{
    public class Member : BaseEntity
    {
        public int UserId { get; set; }
        public int ShoppingListId { get; set; }
        public bool IsAdmin { get; set; }

        public User? User { get; set; }
        public ShoppingList? ShoppingList { get; set; }
    }
}
