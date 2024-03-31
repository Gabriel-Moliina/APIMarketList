namespace APIMarketList.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime IncludedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
