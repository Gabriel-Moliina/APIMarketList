using APIMarketList.Domain.DTO.Product;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
