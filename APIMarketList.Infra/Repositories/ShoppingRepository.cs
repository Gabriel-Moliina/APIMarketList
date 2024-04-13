using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ShoppingRepository : BaseRepository<Shopping>, IShoppingRepository
    {
        public ShoppingRepository(EntityContext context) : base(context)
        {
        }
    }
}
