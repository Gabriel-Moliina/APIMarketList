using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<bool> IsUserAdmin(int shoppingListId, int userId);
    }
}
