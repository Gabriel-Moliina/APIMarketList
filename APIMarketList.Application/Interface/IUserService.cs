using APIMarketList.Domain.DTO.User;

namespace APIMarketList.Service.Interface
{
    public interface IUserService
    {
        Task<UserSaveResponseDTO?> SaveOrUpdate(UserSaveDTO userSaveDTO);
        Task<IList<UserDTO>> Get();
        Task<UserDTO> GetById(int id);
        Task Delete(int id);
        Task<string> Authenticate(string email, string password);
    }
}
