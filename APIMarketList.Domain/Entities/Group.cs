using APIMarketList.Domain.Entities.Base;
using System.Text.RegularExpressions;

namespace APIMarketList.Domain.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            Members = new HashSet<Member>();
            ShoppingLists = new HashSet<ShoppingList>();
        }
        public string? Description { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
