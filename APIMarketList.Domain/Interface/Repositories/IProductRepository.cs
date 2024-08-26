using APIMarketList.Domain.DTO;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<ProductDTO?> GetById(long id);
    }
}
