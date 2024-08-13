using APIMarketList.Domain.Interface.Entities;

namespace APIMarketList.Domain.Entities.Base
{
    public class BaseEntity : TEntity
    {
        public long Id { get; set; }
        public DateTime IncludedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
