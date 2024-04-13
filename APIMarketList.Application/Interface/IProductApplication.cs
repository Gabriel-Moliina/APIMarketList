using APIMarketList.Application.Interface.Base;
using APIMarketList.Domain.DTO;

namespace APIMarketList.Application.Interface
{
    public interface IProductApplication : IBaseApplication
    {
        Task<List<ProductDTO>> GetProductsAsync();
    }
}
