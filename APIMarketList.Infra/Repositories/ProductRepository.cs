using APIMarketList.Domain.DTO;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EntityContext context) : base(context)
        {
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            var entities = await Get();
            return entities.Select(product => new ProductDTO
            {
                Name = product.Name,
                Price = product.Price
            }).ToList();
        }

        public async Task<ProductDTO?> GetById(long id)
        {
            var product = await Get(id);
            return new ProductDTO
            {
                Name = product?.Name,
                Price = product?.Price
            };
        }
    }
}
