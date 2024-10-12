using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Members = new HashSet<Member>();
        }
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}
