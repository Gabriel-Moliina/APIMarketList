using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(EntityContext context) : base(context)
        {
        }

        public async Task<Role> GetByName(string? roleName) => await _dbSet.FirstAsync(x => x.Name == roleName);
    }
}
