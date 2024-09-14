using APIMarketList.Domain.Interface.Entities;

namespace APIMarketList.Domain.Entities.Base
{
    public class BaseEntity : TEntity
    {
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
