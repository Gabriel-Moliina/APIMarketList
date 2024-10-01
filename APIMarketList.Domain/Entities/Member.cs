using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class Member : BaseEntity
    {
        public bool IsAdmin { get; set; }
        public bool CanUpdate { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual User? User { get; set; }
    }
}
