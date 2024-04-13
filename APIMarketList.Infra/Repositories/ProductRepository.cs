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

        public Task<List<ProductDTO>> GetProductsAsync()
        {
            var query = (from product in _dbSet.AsQueryable()
                         select new ProductDTO
                         {
                             Name = product.Name,
                             Price = product.Price
                         });

            return query.ToListAsync();
        }
    }
}
