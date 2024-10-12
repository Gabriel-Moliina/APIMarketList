using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EntityContext context) : base(context)
        {
        }

        public async Task<bool> Exists(string email)
        {
            var result = await _dbSet.AsNoTracking().AnyAsync(x => x.Email == email);
            return result;
        }

        public async Task<User> Login(string email, string password)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetByEmail(string email) => await _dbSet.AsNoTracking().FirstAsync(x => x.Email == email);
    }
}
