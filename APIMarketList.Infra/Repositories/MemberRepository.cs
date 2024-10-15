using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(EntityContext context) : base(context)
        {
        }

        public Task<bool> IsUserAdmin(int shoppingListId, int userId) =>
            _dbSet.AnyAsync(x => x.ShoppingListId == shoppingListId && x.UserId == userId && x.IsAdmin);
    }
}
