using APIMarketList.Domain.DTO.Product;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> Get();
        Task<ProductDTO?> Get(long Id);
        Task<ProductSaveResponseDTO> SaveOrUpdate(ProductSaveDTO productSave);
        Task<int> Delete(int id);
    }
}
