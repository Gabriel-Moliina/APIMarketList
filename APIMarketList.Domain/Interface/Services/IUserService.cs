using APIMarketList.Domain.DTO.User;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IUserService
    {
        Task<UserSaveResponseDTO> SaveOrUpdate(UserSaveDTO userSaveDTO);
        Task<IList<UserDTO>> Get();
        Task<UserDTO> GetById(int id);
        Task Delete(int id);
        Task<string> Authenticate(string login, string password);
    }
}
