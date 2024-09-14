using APIMarketList.Domain.DTO.Product;
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
    }
}
