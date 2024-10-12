using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetByName(string? roleName);
    }
}
