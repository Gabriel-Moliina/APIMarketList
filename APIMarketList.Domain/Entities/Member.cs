using APIMarketList.Domain.Entities.Base;

namespace APIMarketList.Domain.Entities
{
    public class Member : BaseEntity
    {
        public bool IsAdmin { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual User? User { get; set; }
    }
}
