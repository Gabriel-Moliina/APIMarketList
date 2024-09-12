namespace APIMarketList.Domain.DTO.Product
{
    public class ProductSaveDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Code { get; set; } 
    }
}
