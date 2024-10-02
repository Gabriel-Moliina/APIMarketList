using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> Exists(string email);
        Task<User?> Login(string email, string password);
    }
}
