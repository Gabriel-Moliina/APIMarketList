namespace APIMarketList.Domain.DTO.Product
{
    public class ProductSaveResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal Price { get; set; }
    }
}
