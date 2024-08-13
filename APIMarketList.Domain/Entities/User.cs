using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Members = new HashSet<Member>();
        }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
