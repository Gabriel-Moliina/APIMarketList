using APIMarketList.Application.Interface.Base;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Entities;

namespace APIMarketList.Application.Interface
{
    public interface IUserApplication : IBaseApplication
    {
        Task<UserSaveResponseDTO?> SaveOrUpdate(UserSaveDTO userSaveDTO);
        Task<IList<UserDTO>> Get();
        Task<UserDTO> GetById(int id);
        Task<int> Delete(int id);
        Task<string> Authenticate(string email, string password);
    }
}
