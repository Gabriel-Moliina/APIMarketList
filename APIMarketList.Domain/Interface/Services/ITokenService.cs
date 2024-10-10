using APIMarketList.Domain.DTO.User;

namespace APIMarketList.Domain.Interface.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        string GetSecret();
        UserDTO GetUser();
    }
}
