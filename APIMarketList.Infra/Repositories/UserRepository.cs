using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;

namespace APIMarketList.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EntityContext context) : base(context)
        {
        }
    }
}
