namespace APIMarketList.Domain.Interface.Entities
{
    public interface TEntity
    {
        int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
