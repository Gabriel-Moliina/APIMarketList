using APIMarketList.Domain.DTO;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> Get();
        Task<ProductDTO?> Get(long Id);
    }
}
